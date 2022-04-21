using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBookController : BookController<TextBookData>
{
    public override BookModel CreateModel(TextBookData data)
    {

        return base.CreateModel(data);
    }
}
