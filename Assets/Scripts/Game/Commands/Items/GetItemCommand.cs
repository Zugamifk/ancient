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
        ItemModel itemModel;
        switch (data)
        {
            case TextBookData textbookData:
                var bookMaker = new BookMaker();
                itemModel = bookMaker.CreateTextBookModel(textbookData);
                break;
            case PackageItemData packageData:
                itemModel = new PackageItemModel()
                {
                    Contents = packageData.Contents.Select(i=>i.Name).ToList()
                };
                break;
            default:
                itemModel = new ItemModel();
                break;
        }

        itemModel.Key = data.Name;
        itemModel.DeskSpawnLocation = data.DeskSpawnLocation;

        model.Inventory.Items.AddItem(itemModel, _itemName);
        Debug.Log($"Receieved {itemModel.Key} ({itemModel.Id})");
    }
}
