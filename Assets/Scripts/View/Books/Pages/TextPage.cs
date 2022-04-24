using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextPage : Page<ITextPageModel>
{
    [SerializeField]
    TextMeshPro _text;

    public int PageIndex { get; set; }

    public override void SetPage(ITextPageModel model)
    {
        _text.pageToDisplay = PageIndex;
        _text.text = model.Text;
    }
}
