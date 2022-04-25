using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController
{
    TextBookController _textbookController = new TextBookController();

    ItemCollection _collection;

    public ItemController(ItemCollection collection)
    {
        _collection = collection;
    }

    public void AddItem(string name, InventoryModel inventoryModel)
    {
        var data = _collection.GetData(name);
        ItemModel model = null;
        switch (data)
        {
            case TextBookData textbookData:
                var textbook = _textbookController.CreateModel(textbookData);
                textbook.ClickedItem += (_, _) => textbook.IsOpen = true;
                model = textbook;
                break;
            default:
                model = new ItemModel();
                break;
        }

        model.Name = data.Name;
        model.DeskSpawnLocation = data.DeskSpawnLocation;

        inventoryModel.Items.Add(name, model);

        if(data is PackageItemData package)
        {
            model.ClickedItem += (_, _) =>
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
