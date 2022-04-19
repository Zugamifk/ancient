using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController
{
    public BookModel CreateBookModel()
    {
        var book = new BookModel();
        book.IndexChanged += (_, pageIndex) => book.Index = pageIndex;
        return book;
    }
}
