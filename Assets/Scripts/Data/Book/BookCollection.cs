using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookCollection : ScriptableObject
{
    [SerializeField]
    TextBookData[] _textBooks;

    Dictionary<string, TextBookData> _nameToTextBookData = new Dictionary<string, TextBookData>();

    public BookData GetBook(string name)
    {
        return _nameToTextBookData[name];
    }

    private void OnEnable()
    {
        foreach (var b in _textBooks)
        {
            _nameToTextBookData[b.Name] = b;
        }
    }
}
