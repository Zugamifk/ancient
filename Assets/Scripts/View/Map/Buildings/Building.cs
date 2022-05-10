using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Identifiable))]
public class Building : MonoBehaviour, IView<IBuildingModel>
{
    [SerializeField]
    Highlighter _highlighter;
    [SerializeField]
    Transform _entrance;

    Identifiable _identifiable;

    public Vector3 EntrancePosition => _entrance.position;

    IBuildingModel _model;

    private void Awake()
    {
        _identifiable = GetComponent<Identifiable>();
        GetComponent<Clickable>().Clicked += Clicked;
    }

    void Clicked(int button)
    {
        _highlighter.Highlight(!_highlighter.IsHighlighted);
        if (_model != null)
        {
            _model.OnClicked(button);
        }
    }

    public void InitializeFromModel(IBuildingModel model)
    {
        _identifiable.Id = model.Id;
    }
}
