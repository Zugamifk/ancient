using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookModel : IBookModel
{
    public string Name { get; set; }
    public List<IPageModel> Pages { get; } = new List<IPageModel>();

    public int NumPages => 5;

    public int Index { get; set; }

    public event EventHandler<int> IndexChanged;

    public void OnIndexChanged(int index)
    {
        IndexChanged?.Invoke(this, index);
    }
}
