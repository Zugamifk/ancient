using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Identifiable))]
public class MapPositionable : MonoBehaviour
{
    public Func<Guid, Vector3> PositionGetter;
    Identifiable _identifiable;

    void Awake()
    {
        _identifiable = GetComponent<Identifiable>();
    }

    public void Update()
    {
        var position = PositionGetter?.Invoke(_identifiable.Id); ;
        if (position.HasValue)
        {
            transform.position = position.Value;
        }
    }
}
