using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Book : MonoBehaviour, IModelUpdateable
{
    [SerializeField]
    string _name;
    [SerializeField]
    TextPage _textPage;
    [SerializeField]
    CharacterProfilePage _characterPage;
    [SerializeField]
    RectTransform _leftPage;
    [SerializeField]
    RectTransform _rightPage;
    [SerializeField]
    Button _turnLeftbutton;
    [SerializeField]
    Button _turnRightbutton;
    [SerializeField]
    Button _closeButton;

    string _currentBook;
    int _currentPage = 0;
    bool _closing;

    public string Name => _name;

    private void Awake()
    {
        _turnLeftbutton.onClick.AddListener(Clicked_TurnLeftButton);
        _turnRightbutton.onClick.AddListener(Clicked_TurnRightButton);
        _closeButton.onClick.AddListener(Clicked_Close);
    }
    public void UpdateFromModel(IGameModel model)
    {
        var book = model.Inventory.GetItem(Name) as IBookModel;
        if (_closing)
        {
            book.OnClosed();
            _closing = false;
        }

        if (book.IsOpen!=gameObject.activeInHierarchy)
        {
            gameObject.SetActive(book.IsOpen);
        }

        if (!book.IsOpen)
        {
            return;
        }

        if (_currentBook != book.Name)
        {
            _currentBook = book.Name;
            _currentPage = book.Index;
            UpdatePages(book);
        }
        else if (_currentPage != book.Index)
        {
            book.OnIndexChanged(_currentPage);
            UpdatePages(book);
        }
    }

    void UpdatePages(IBookModel book)
    {
        SetPage(book.Pages[_currentPage], _leftPage);
        if (_currentPage + 1 < book.NumPages)
        {
            SetPage(book.Pages[_currentPage + 1], _rightPage);
        }

        _turnLeftbutton.gameObject.SetActive(_currentPage > 0);
        _turnRightbutton.gameObject.SetActive(_currentPage < book.NumPages - 2);
    }

    void SetPage(IPageModel pageModel, RectTransform pageRoot)
    {
        switch (pageModel)
        {
            case ITextPageModel tp:
                {
                    var page = SetPage(tp, _textPage, pageRoot);
                    page.PageIndex = _currentPage;
                }
                break;
            case ICharacterProfilePageModel cp:
                {
                    SetPage(cp, _characterPage, pageRoot);
                }
                break;
            default:
                break;
        }
    }

    TPage SetPage<TModel, TPage>(TModel model, TPage prefab, RectTransform parent)
        where TModel : IPageModel
        where TPage : Page<TModel>
    {
        var page = Instantiate(prefab);
        page.SetPage(model);

        var tf = page.GetComponent<RectTransform>();
        tf.SetParent(parent);
        tf.sizeDelta = Vector2.zero;
        tf.anchorMin = Vector2.zero;
        tf.anchorMax = Vector2.one;
        tf.anchoredPosition = Vector2.zero;
        page.gameObject.SetActive(true);
        return page;
    }

    void Clicked_TurnLeftButton()
    {
        _currentPage -= 2;
    }

    void Clicked_TurnRightButton()
    {
        _currentPage += 2;
    }

    void Clicked_Close()
    {
        _closing = true;
    }
}
