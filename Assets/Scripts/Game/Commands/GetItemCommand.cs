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
            case TextBookData textbookData:
                var textbook = CreateTextBookModel(textbookData);
                textbook.ClickedItem += _ => textbook.IsOpen = true;
                itemModel = textbook;
                break;
            default:
                itemModel = new ItemModel();
                break;
        }

        itemModel.Key = data.Name;
        itemModel.DeskSpawnLocation = data.DeskSpawnLocation;

        model.Inventory.Items.AddItem(itemModel, _itemName);
    }

    BookModel CreateTextBookModel(TextBookData data)
    {
        var book = CreateBookModel(data);
        book.Pages.Add(CreateCharacterProfilePageModel(data.Profile));
        book.Pages.Add(new TextPageModel() { Text = data.Text });
        return book;
    }

    BookModel CreateBookModel(BookData data)
    {
        var book = new BookModel();
        book.Key = data.Name;
        book.IndexChanged += pageIndex => book.Index = pageIndex;
        book.Closed += () => book.IsOpen = false;
        return book;
    }

    CharacterProfilePageModel CreateCharacterProfilePageModel(CharacterData data)
    {
        return new CharacterProfilePageModel()
        {
            Name = data.DisplayName,
            DateOfBirth = data.DateOfBirth,
            Address = data.Address,
            Biography = data.Biography
        };
    }
}
