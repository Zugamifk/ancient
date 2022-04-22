using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBookController : BookController<TextBookData>
{
    public override BookModel CreateModel(TextBookData data)
    {
        var book = base.CreateModel(data);
        book.Pages.Add(new PageModel() { Text = data.Text });
        return book;
    }
}
