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
    }
}
