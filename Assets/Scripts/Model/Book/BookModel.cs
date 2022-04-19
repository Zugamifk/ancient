using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookModel : IBookModel
{
    public List<PageModel> Pages = new List<PageModel>();

    public int NumPages => 5;

    public int Index;

    public event EventHandler<int> IndexChanged;

    public void OnIndexChanged(int index)
    {
        IndexChanged?.Invoke(this, index);
    }

    #region IBookModel
    int IBookModel.Index => Index;
    #endregion
}
