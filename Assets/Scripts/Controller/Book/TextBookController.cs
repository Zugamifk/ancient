using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBookController : BookController<TextBookData>
{
    public override BookModel CreateModel(TextBookData data)
    {
        var book = base.CreateModel(data);
        book.Pages.Add(new CharacterProfilePageModel());
        book.Pages.Add(new TextPageModel() { Text = data.Text });
        return book;
    }
}
