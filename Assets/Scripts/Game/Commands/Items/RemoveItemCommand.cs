using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

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
        model.AllIdentifiables.RemoveItem(_id);
    }
}
