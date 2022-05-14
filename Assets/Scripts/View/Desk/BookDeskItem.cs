using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookDeskItem : DeskItem
{
    public void Update()
    {
        var book = Game.Model.Inventory.GetItem(Name) as IBookModel;
        gameObject.SetActive(!book.IsOpen);
    }
}
