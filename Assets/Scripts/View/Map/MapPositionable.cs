using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Identifiable))]
public class MapPositionable : MonoBehaviour
{
    public Func<Guid, IMapPositionable> PositionGetter;
    Identifiable _identifiable;

    void Awake()
    {
        _identifiable = GetComponent<Identifiable>();
    }

    public void Update()
    {
        var positionable = PositionGetter?.Invoke(_identifiable.Id);
        if (positionable != null)
        {
        }
    }
}
