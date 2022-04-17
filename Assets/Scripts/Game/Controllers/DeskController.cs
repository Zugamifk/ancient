using System;
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

    public void AddItem(string name, DeskModel deskModel)
    {
        var data = _collection.GetItem(name);
        var itemModel = new DeskItemModel()
        {
            Name = data.Name
        };
        deskModel.Items.Add(name, itemModel);

        if(data is PackageItemData package)
        {
            itemModel.ClickedItem += (_, button) => {
                Debug.Log("Opening " + name);
                RemoveItem(name, deskModel);
                foreach (var item in package.Contents)
                {
                    AddItem(item, deskModel);
                }
            };
        }
    }

    void RemoveItem(string name, DeskModel model)
    {
        model.Items.Remove(name);
    }
}
