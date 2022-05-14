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

    public void Execute(GameModel model)
    {
        var data = DataService.GetData<ItemCollection>().GetData(_itemName);
        ItemModel itemModel = null;
        switch (data)
        {
            //case TextBookData textbookData:
            //    var textbook = _textbookController.CreateModel(textbookData);
            //    textbook.ClickedItem += _ => textbook.IsOpen = true;
            //    model = textbook;
            //    break;
            default:
                itemModel = new ItemModel();
                break;
        }

        itemModel.Name = data.Name;
        itemModel.DeskSpawnLocation = data.DeskSpawnLocation;

        model.Inventory.Items.AddItem(itemModel, _itemName);
    }
}
