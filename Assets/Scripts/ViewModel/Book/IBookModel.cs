using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBookModel 
{
    string Key { get; }
    int NumPages { get; }
    int Index { get; }
    bool IsOpen { get; set; }
    List<IPageModel> Pages { get; }
}
