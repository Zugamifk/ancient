using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemCommand : ICommand
{
    string _itemName;

    public GetItemCommand(string itemName)
    {
        _itemName = itemName;
    }

    public void Execute(GameController controller)
    {
        controller.ItemController.AddItem(_itemName, controller.Model.Desk);
    }
}
