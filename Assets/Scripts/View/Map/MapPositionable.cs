using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Identifiable))]
public class MapPositionable : MonoBehaviour, IModelUpdateable
{
    public Func<IGameModel, Guid, IMapPositionable> PositionGetter;
    Identifiable _identifiable;
    Vector2 _positionOffset = Vector2.one;

    void Awake()
    {
        _identifiable = GetComponent<Identifiable>();
        _positionOffset = new Vector2(0.5f - UnityEngine.Random.value, .5f - UnityEngine.Random.value);
    }

    void Start()
    {
        UpdateableGameObjectRegistry.RegisterUpdateable(this);
    }

    public void UpdateFromModel(IGameModel model)
    {
        var positionable = PositionGetter.Invoke(model, _identifiable.Id);
        if (positionable != null)
        {
            transform.position = model.Map.TileMapTransformer.ModelToWorld(positionable.Position + _positionOffset);
        }
    }
}
