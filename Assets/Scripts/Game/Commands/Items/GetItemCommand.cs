using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GetItemCommand : ICommand
{
    string _itemName;

    public GetItemCommand(string itemName)
    {
        _itemName = itemName;
    }

    public void Execute(GameModel model)
    {
        var data = DataService.GetData<ItemCollection>().GetData(_itemName);
        var itemModel = ModelBuilder.GetModel(data);

        model.Inventory.Items.AddItem(itemModel, _itemName);
        model.AllIdentifiables.AddItem(itemModel, _itemName);
    }
}
