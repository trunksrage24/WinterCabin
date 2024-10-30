using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using System;

public class BookDisplay : MonoBehaviour
{
    [SerializeField]
    private List<BookContent> bookContents;

    [SerializeField]
    private GameObject openedBook;
    private int bookID;
    private int currentPage;

    private void Start()
    {
        currentPage = 0;
    }

    private void ChangePage(int cur, int page, BookContent content)
    {
        if(cur + page > content.contents.Count)
        {
            return;
        } 
        else
        {
            currentPage += currentPage + page;
            UpdatePage(currentPage);
        }
    }

    private void UpdatePage(int currentPage)
    {
        Renderer renderer = openedBook.GetComponent<Renderer>();
        Material currentMaterial = renderer.material;

        
    }
}
