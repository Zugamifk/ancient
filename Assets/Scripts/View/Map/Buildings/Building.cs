using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField]
    Highlighter _highlighter;
    [SerializeField]
    Transform _entrance;

    public Vector3 EntrancePosition => _entrance.position;

    IBuildingModel _model;
    IBuildingBehaviour _building;
    private void Start()
    {
        _building = GetComponent<IBuildingBehaviour>();
        GetComponent<Clickable>().Clicked += Clicked;
    }

    public void UpdateModel(IBuildingModel building, IGameModel model)
    {
        _model = building;
        if (_building != null)
        {
            _building.UpdateModel(model);
        }
    }

    void Clicked(object _, int button)
    {
        _highlighter.Highlight(!_highlighter.IsHighlighted);
        if (_model != null)
        {
            _model.OnClicked(button);
        }
    }
}
