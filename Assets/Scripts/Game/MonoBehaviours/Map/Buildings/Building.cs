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

    IBuildingBehaviour _building;
    private void Start()
    {
        _building = GetComponent<IBuildingBehaviour>();
        GetComponent<Clickable>().Clicked += (_, _) => _highlighter.Highlight(!_highlighter.IsHighlighted);
    }

    public void FrameUpdate(IGameModel model)
    {
        if (_building != null)
        {
            _building.FrameUpdate(model);
        }
    }
}
