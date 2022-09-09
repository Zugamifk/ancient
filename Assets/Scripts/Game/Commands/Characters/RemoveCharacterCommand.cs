using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

public class RemoveCharacterCommand : ICommand
{
    Guid _id;

    public RemoveCharacterCommand(Guid id) => _id = id;

    public void Execute(GameModel model)
    {
        model.Characters.RemoveItem(_id);
        model.AllIdentifiables.RemoveItem(_id);
    }
}
