using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Model;

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
        var itemModel = ItemModelFactory.GetModel(data);

        model.Inventory.Items.AddItem(itemModel);
        model.AllIdentifiables.AddItem(itemModel);
    }
}
