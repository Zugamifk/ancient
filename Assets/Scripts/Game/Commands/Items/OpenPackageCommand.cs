using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

public class OpenPackageCommand : ICommand
{
    Guid _id;
    public OpenPackageCommand(Guid id)
    {
        _id = id;
    }

    public void Execute(GameModel model)
    {
        Game.Do(new RemoveItemCommand(_id));

        var item = model.Inventory.Items.GetItem(_id);
        if(item is not PackageItemModel package)
        {
            throw new InvalidOperationException($"Item {item.Key} ({_id}) is not a package!");
        }

        Debug.Log($"Opening {item.Key} ({item.Id})");

        foreach (var packageItem in package.Contents)
        {
            Game.Do(new GetItemCommand(packageItem));
        }
    }
}
