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
        ItemModel itemModel;
        switch (data)
        {
            case TextBookData textbookData:
                var bookMaker = Services.Get<BookMaker>();
                itemModel = bookMaker.CreateTextBookModel(textbookData);
                break;
            default:
                itemModel = new ItemModel();
                break;
        }

        itemModel.Key = data.Name;
        itemModel.DeskSpawnLocation = data.DeskSpawnLocation;

        model.Inventory.Items.AddItem(itemModel, _itemName);
    }
}
