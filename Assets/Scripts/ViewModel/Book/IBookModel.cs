using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBookModel : IIsOpen
{
    string Key { get; }
    int NumPages { get; }
    int Index { get; }
    List<IPageModel> Pages { get; }
}
