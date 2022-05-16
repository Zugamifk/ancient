using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Identifiable))]
public class BookDeskItem : DeskItem
{
    [SerializeField]
    Clickable _clickable;

    private void Start()
    {
        _clickable.Clicked += Clicked;
    }

    public void Update()
    {
        var book = Game.Model.Inventory.GetItem(Name) as IBookModel;
        gameObject.SetActive(!book.IsOpen);
    }

    void Clicked(int button)
    {
        var identifiable = GetComponent<Identifiable>();
        Game.Do(new ExamineItemCommand(identifiable.Id));
    }
}
