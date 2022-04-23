using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDeskItemCommand : ICommand
{
    string _itemName;

    public SpawnDeskItemCommand(string itemName)
    {
        _itemName = itemName;
    }

    public void Execute(GameController controller)
    {
        controller.DeskController.AddItem(_itemName, controller.Model.Desk);
    }
}
