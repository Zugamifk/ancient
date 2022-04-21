using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookController
{
    
}

public abstract class BookController<TData> : BookController 
    where TData : BookData 
{
    public virtual BookModel CreateModel(TData data)
    {
        var book = new BookModel();
        book.IndexChanged += (_, pageIndex) => book.Index = pageIndex;
        return book;
    }
}
