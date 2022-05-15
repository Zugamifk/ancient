using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementModel : IIdentifiable
{
    // live data
    public Guid OwnerId { get; set; }
    public Vector2 WorldPosition { get; set; }
    public string EnteredLocation;
    public CityPath CityPath;

    /// <summary>
    /// The index of the path node we are current moving towards
    /// </summary>
    public int CurrentPathIndex;
    public float MoveSpeed;

    public event Action<MovementModel> ReachedPathEnd;

    public bool AtPathEnd => CityPath.Path == null || CurrentPathIndex >= CityPath.Path.Count;
    public bool IsVisibleOnMap => string.IsNullOrEmpty(EnteredLocation);

    Guid IIdentifiable.Id => OwnerId;

    public void OnReachedPathEnd()
    {
        ReachedPathEnd?.Invoke(this);
        ReachedPathEnd = null;
        CityPath = null;
    }
}
