using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCharacterCommand : ICommand
{
    Guid _id;

    public RemoveCharacterCommand(Guid id) => _id = id;

    public void Execute(GameModel model)
    {
        model.Characters.RemoveItem(_id);
    }
}
