using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookMaker
{
    public BookModel CreateTextBookModel(TextBookData data)
    {
        var book = CreateBookModel(data);
        book.Pages.Add(CreateCharacterProfilePageModel(data.Profile));
        book.Pages.Add(new TextPageModel() { Text = data.Text });
        return book;
    }

    public BookModel CreateBookModel(BookData data)
    {
        var book = new BookModel();
        book.Key = data.Name;
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
