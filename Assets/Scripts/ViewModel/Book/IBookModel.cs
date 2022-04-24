using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBookModel 
{
    string Name { get; }
    int NumPages { get; }
    int Index { get; }
    event EventHandler<int> IndexChanged;
    void OnIndexChanged(int index);

    List<IPageModel> Pages { get; }
}
