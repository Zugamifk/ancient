using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskController
{
    DeskItemCollection _collection;
    public DeskController(DeskItemCollection collection)
    {
        _collection = collection;
    }

    public void AddItem(string name, DeskModel model)
    {
        var data = _collection.GetItem(name);
        model.Items.Add(name, new DeskItemModel()
        {
            Name = data.Name
        });
    }
}
