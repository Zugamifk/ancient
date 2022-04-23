using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorkBook : MonoBehaviour
{
    [SerializeField]
    TextMeshPro _leftPage;
    [SerializeField]
    TextMeshPro _rightPage;
    [SerializeField]
    Button _turnLeftbutton;
    [SerializeField]
    Button _turnRightbutton;

    string _currentBook;
    int _currentPage = 0;

    private void Awake()
    {
        _turnLeftbutton.onClick.AddListener(Clicked_TurnLeftButton);
        _turnRightbutton.onClick.AddListener(Clicked_TurnRightButton);
    }

    public void UpdateModel(IBookModel book, IGameModel model)
    {
        if (_currentBook != book.Name)
        {
            _currentBook = book.Name;
            _currentPage = book.Index;
            UpdatePages(book);
        } else if (_currentPage != book.Index)
        {
            book.OnIndexChanged(_currentPage);
            UpdatePages(book);
        }
    }

    void UpdatePages(IBookModel book)
    {
        _leftPage.text = book.Pages[0].Text;
        _leftPage.pageToDisplay = _currentPage;
        _rightPage.text = book.Pages[0].Text;
        _rightPage.pageToDisplay = _currentPage + 1;

        _turnLeftbutton.interactable = _currentPage > 0;
        _turnRightbutton.interactable = _currentPage < book.NumPages - 1;
    }

    void Clicked_TurnLeftButton()
    {
        _currentPage-=2;
    }

    void Clicked_TurnRightButton()
    {
        _currentPage+=2;
    }
}
