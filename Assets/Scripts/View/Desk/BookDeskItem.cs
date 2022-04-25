using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookDeskItem : DeskItem, IModelUpdateable
{
    public void UpdateFromModel(IGameModel model)
    {
        var book = model.Inventory.GetItem(Name) as IBookModel;
        gameObject.SetActive(!book.IsOpen);
    }
}
