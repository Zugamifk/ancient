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
        book.Name = data.Name;
        book.IndexChanged += (_, pageIndex) => book.Index = pageIndex;
        book.Closed += (_, _) => book.IsOpen = false;
        return book;
    }
}
