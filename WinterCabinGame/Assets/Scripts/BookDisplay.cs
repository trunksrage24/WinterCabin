using UnityEngine;
using System.Collections.Generic;

public class BookDisplay : MonoBehaviour
{
    [SerializeField]
    private List<BookContent> bookContents;

    [SerializeField]
    private Slot slot;

    [SerializeField]
    private GameObject openedBook;

    [SerializeField]
    private Transform openedBookPivot;

    [SerializeField]
    private Button rightButton;

    [SerializeField]
    private Button leftButton;

    [SerializeField]
    private GameObject pageChangers;

    private Book book;
    private GameObject instanceBook;
    private int bookID = 0;
    private int currentPage = 0;

    private void Start()
    {
        if(slot.Contained != null)
        {
            ObtainBookData();
        }
    
        slot.OnPlace += HandleSlotPlace;
        slot.OnTake += BookReset;
        rightButton.OnCLick += HandleButtonClick;
        leftButton.OnCLick += HandleButtonClick;

    }
    private void ObtainBookData()
    {
        book = slot.Contained;
        bookID = book.id;
        Debug.Log($"{bookID}");
    }
    private void HandleSlotPlace()
    {
        ObtainBookData();
        instanceBook = Instantiate(openedBook, openedBookPivot);
        UpdatePage();
        pageChangers.SetActive(true);
        return;
    }

    private void HandleButtonClick(Button button)
    {
        if(button == rightButton)
            ChangePage(currentPage, 1, bookContents[bookID]);
        else if(button == leftButton)
            ChangePage(currentPage, -1, bookContents[bookID]);
        else
            return;
    }

    private void ChangePage(int curpage, int page, BookContent content)
    {
        if(curpage + page >= content.contents.Count || curpage + page < 0)
        {
            return;
        } 
        else
        {
            currentPage += page;
            UpdatePage();
        }
    }

    private void UpdatePage()
    {
        Material newMaterial = bookContents[bookID].contents[currentPage];
        instanceBook.GetComponent<Renderer>().material = newMaterial;
        
        Debug.Log($"{currentPage}");
    }

    private void BookReset()
    {
        currentPage = 0;
        bookID = 0;
        book = null;
        Destroy(instanceBook);
        pageChangers.SetActive(false);
    }
}
