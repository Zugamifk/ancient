using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorkBook : MonoBehaviour
{
    [SerializeField]
    TextPage _textPage;
    [SerializeField]
    RectTransform _leftPage;
    [SerializeField]
    RectTransform _rightPage;
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
        SetPage(book.Pages[_currentPage], _leftPage);
        if (_currentPage+1 < book.NumPages)
        {
            SetPage(book.Pages[_currentPage + 1], _rightPage);
        }

        _turnLeftbutton.interactable = _currentPage > 0;
        _turnRightbutton.interactable = _currentPage < book.NumPages - 1;
    }

    void SetPage(IPageModel pageModel, RectTransform pageRoot)
    {
        switch (pageModel)
        {
            case ITextPageModel tp:
                {
                    var page = Instantiate(_textPage);
                    page.SetPage(tp);
                    page.PageIndex = _currentPage;
                    var tf = page.GetComponent<RectTransform>();
                    tf.SetParent(pageRoot);
                    tf.sizeDelta = Vector2.zero;
                    tf.anchorMin = Vector2.zero;
                    tf.anchorMax = Vector2.one;
                    tf.anchoredPosition = Vector2.zero;
                    page.gameObject.SetActive(true);
                } break;
            default:
                break;
        }
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
