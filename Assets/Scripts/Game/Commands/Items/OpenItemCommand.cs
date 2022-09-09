using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

public class OpenItemCommand : ICommand
{
    Guid _id;

    public OpenItemCommand(Guid id) => _id = id;
    public void Execute(GameModel model)
    {
        var openable = model.AllIdentifiables.GetItem(_id) as IOpenable;
        openable.IsOpen = true;
    }
}
