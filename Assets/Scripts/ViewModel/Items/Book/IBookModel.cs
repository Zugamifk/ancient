using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBookModel : IItemModel, IIsExamining
{
    int NumPages { get; }
    int Index { get; }
    List<IPageModel> Pages { get; }
}
