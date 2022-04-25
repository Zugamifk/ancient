using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController
{
    ItemCollection _collection;

    public ItemController(ItemCollection collection)
    {
        _collection = collection;
    }

    public void AddItem(string name, InventoryModel inventoryModel)
    {
        var data = _collection.GetData(name);
        var itemModel = new ItemModel()
        {
            Name = data.Name,
            DeskSpawnLocation = data.DeskSpawnLocation
        };
        inventoryModel.Items.Add(name, itemModel);

        if(data is PackageItemData package)
        {
            itemModel.ClickedItem += (_, _) =>
            {
                OpenPackage(package, inventoryModel);
            };
        }
    }

    void RemoveItem(string name, InventoryModel model)
    {
        model.Items.Remove(name);
    }

    void OpenPackage(PackageItemData package, InventoryModel model)
    {
        RemoveItem(package.Name, model);
        foreach(var item in package.Contents)
        {
            AddItem(item.Name, model);
        }
    }
}
