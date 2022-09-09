using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;
using Model;

public class UpdateBodyCommand : ICommand
{
    Guid _id;

    public UpdateBodyCommand(Guid id) => _id = id;

    public void Execute(GameModel model)
    {
        var character = model.Characters.GetItem(_id);
        var body = character.Health.Body;
        if(!body.Heart.IsBeating)
        {
            // dead
            return;
        }
    }
}
