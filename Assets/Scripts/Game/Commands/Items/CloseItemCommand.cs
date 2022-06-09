using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseItemCommand : ICommand
{
    Guid _id;

    public CloseItemCommand(Guid id) => _id = id;
    public void Execute(GameModel model)
    {
        var openable = model.AllIdentifiables.GetItem(_id) as IOpenable;
        openable.IsOpen = false;
    }
}