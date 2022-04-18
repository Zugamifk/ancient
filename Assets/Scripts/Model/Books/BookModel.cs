using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookModel
{
    public List<PageModel> Pages = new List<PageModel>();
    public int CurrentPageIndex;
    public bool IsOpen;
}
