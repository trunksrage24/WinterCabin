using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;
using TMPro;

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

    private Book book;
    private int bookID = 0;
    private int currentPage = 0;

    private void Start()
    {
        if(slot.Contained != null)
        {
            ObtainBookData();
        }
    
        slot.OnPlace += HandleSlotPlace;
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
        Instantiate(openedBook, openedBookPivot);
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
        if(curpage + page > content.contents.Count || curpage + page < 0)
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
        Renderer renderer = openedBook.GetComponent<Renderer>();
        //Material currentMaterial = renderer.material;
        Material newMaterial = bookContents[bookID].contents[currentPage];

        renderer.material = newMaterial;
        Debug.Log($"{currentPage}");
    }
}
