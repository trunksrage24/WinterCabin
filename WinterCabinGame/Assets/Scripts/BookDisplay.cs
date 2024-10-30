using UnityEngine;
using System.Collections.Generic;

public class BookDisplay : MonoBehaviour
{
    [SerializeField]
    private List<BookContent> bookContents;

    [SerializeField]
    private GameObject openedBook;
    private int bookID;

    private int currentPage;


}
