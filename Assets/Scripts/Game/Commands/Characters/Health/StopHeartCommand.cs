using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

public class StopHeartCommand : ICommand
{
    Guid _id;
    
    public StopHeartCommand(Guid id) => _id = id;

    public void Execute(GameModel model)
    {
        var c = model.Characters.GetItem(_id);
        c.Health.Body.Heart.IsBeating = false;
    }
}
