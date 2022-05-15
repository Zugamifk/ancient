using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookModel : ItemModel, IItemModel, IBookModel
{
    public List<IPageModel> Pages { get; } = new List<IPageModel>();

    public int NumPages => Pages.Count;

    public int Index { get; set; }

    public bool IsOpen { get; set; }
}
