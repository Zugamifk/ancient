using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookModel : ItemModel, IItemModel, IBookModel
{
    public List<IPageModel> Pages { get; } = new List<IPageModel>();

    public int NumPages => Pages.Count;

    public int Index { get; set; }

    public event Action<int> IndexChanged;
    public event Action  Closed;

    public bool IsOpen { get; set; }

    public void OnIndexChanged(int index)
    {
        IndexChanged?.Invoke(index);
    }

    public void OnClosed()
    {
        Closed?.Invoke();
    }
}
