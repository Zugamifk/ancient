using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorkBook : MonoBehaviour
{
    [SerializeField]
    Text _leftPage;
    [SerializeField]
    Text _rightPage;
    [SerializeField]
    Button _turnLeftbutton;
    [SerializeField]
    Button _turnRightbutton;

    int _currentPage = 0;

    private void Awake()
    {
        _turnLeftbutton.onClick.AddListener(Clicked_TurnLeftButton);
        _turnRightbutton.onClick.AddListener(Clicked_TurnRightButton);
    }

    public void UpdateModel(IBookModel book, IGameModel model)
    {
        if (_currentPage != book.Index)
        {
            _leftPage.text = book.Pages[0].Text;

            book.OnIndexChanged(_currentPage);
            _turnLeftbutton.interactable = _currentPage > 0;
            _turnRightbutton.interactable = _currentPage < book.NumPages - 1;
        }
    }

    void Clicked_TurnLeftButton()
    {
        _currentPage--;
    }

    void Clicked_TurnRightButton()
    {
        _currentPage++;
    }
}
