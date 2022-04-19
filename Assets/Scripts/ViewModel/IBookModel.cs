using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBookModel 
{
    int NumPages { get; }
    int Index { get; }
    event EventHandler<int> IndexChanged;
    void OnIndexChanged(int index);
}
