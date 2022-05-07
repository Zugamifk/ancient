using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCharacterCommand : ICommand
{
    public string CharacterId;
    public void Execute(GameController controller)
    {
        controller.Model.Characters.RemoveItem(CharacterId);
    }
}
