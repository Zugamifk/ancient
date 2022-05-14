using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Identifiable))]
public class MapPositionable : MonoBehaviour
{
    public Func<Guid, IMapPositionable> PositionGetter;
    Identifiable _identifiable;
    Vector2 _positionOffset = Vector2.one;

    void Awake()
    {
        _identifiable = GetComponent<Identifiable>();
        _positionOffset = new Vector2(0.5f - UnityEngine.Random.value, .5f - UnityEngine.Random.value);
    }

    public void Update()
    {
        var positionable = PositionGetter.Invoke(_identifiable.Id);
        if (positionable != null)
        {
            transform.position = Game.Model.Map.TileMapTransformer.ModelToWorld(positionable.Position + _positionOffset);
        }
    }
}
