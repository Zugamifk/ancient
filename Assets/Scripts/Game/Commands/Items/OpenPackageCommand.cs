using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPackageCommand : ICommand
{
    Guid _id;
    public OpenPackageCommand(Guid id)
    {
        _id = id;
    }

    public void Execute(GameModel model)
    {

        var item = model.Inventory.Items.GetItem(_id);
        Debug.Log($"Opening {item.Key} ({item.Id})");
        if(item is not PackageItemModel package)
        {
            throw new InvalidOperationException($"Item {item.Key} ({_id}) is not a package!");
        }

        foreach(var packageItem in package.Contents)
        {
            Game.Do(new GetItemCommand(packageItem));
        }
    }
}
