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
    bool IsOpen { get; set; }

    List<IPageModel> Pages { get; }
}
