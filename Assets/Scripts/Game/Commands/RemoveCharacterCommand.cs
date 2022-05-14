using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCharacterCommand : ICommand
{
    public Guid CharacterId;
    public void Execute(GameModel model)
    {
        model.Characters.RemoveItem(CharacterId);
    }
}
