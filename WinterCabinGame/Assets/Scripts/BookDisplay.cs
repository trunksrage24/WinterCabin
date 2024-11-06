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

    private Book book;
    private int bookID = 0;
    private int currentPage = 0;

    private void Start()
    {
        if(slot.Contained != null)
        {
            ObtainBookData();
        }
        else
            return;

        slot.OnPlace += HandleSlotPlace;
    }
    private void ObtainBookData()
    {
        book = slot.Contained;
        bookID = book.id;
    }
    private void HandleSlotPlace()
    {
        ObtainBookData();
        Instantiate(openedBook, openedBookPivot);
        return;
    }

    private void ChangePage(int cur, int page, BookContent content)
    {
        if(cur + page > content.contents.Count || cur + page < 0)
        {
            return;
        } 
        else
        {
            currentPage += currentPage + page;
            UpdatePage();
        }
    }

    private void UpdatePage()
    {
        Renderer renderer = openedBook.GetComponent<Renderer>();
        Material currentMaterial = renderer.material;
        Material newMaterial = bookContents[bookID].contents[currentPage];

        renderer.material = newMaterial;
    }
}
