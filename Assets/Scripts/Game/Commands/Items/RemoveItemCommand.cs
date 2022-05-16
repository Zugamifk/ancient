using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveItemCommand : ICommand
{
    Guid _id;
    public RemoveItemCommand(Guid id)
    {
        _id = id;
    }

    public void Execute(GameModel model)
    {
        model.Inventory.Items.RemoveItem(_id);
    }
}
