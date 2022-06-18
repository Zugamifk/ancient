using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BookMaker
{
    [RuntimeInitializeOnLoadMethod]
    static void RegisterBookDataFactory()
    {
        ModelFactory.RegisterFactory<TextBookData>(CreateTextBookModel);
    }

    public static ItemModel CreateTextBookModel(ItemData data)
    {
        var bookData = (TextBookData)data;
        var book = CreateBookModel(bookData);
        book.Pages.Add(CreateCharacterProfilePageModel(bookData.Profile));
        book.Pages.Add(new TextPageModel() { Text = bookData.Text });
        return book;
    }

    public static BookModel CreateBookModel(BookData data)
    {
        var book = new BookModel();
        book.Key = data.Name;
        return book;
    }

    static CharacterProfilePageModel CreateCharacterProfilePageModel(CharacterData data)
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
