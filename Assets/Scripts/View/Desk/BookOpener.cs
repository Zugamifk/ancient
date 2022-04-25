using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookOpener : DeskItem
{
    [SerializeField]
    Clickable _clickable;
    [SerializeField]
    Book _targetBook;

    private void Start()
    {
        _clickable.Clicked += Clicked;
    }

    void Clicked(object _, int button)
    {
        _targetBook?.Open();
    }
}
