using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MapMovementModel : IIdentifiable
{
    // live data
    public Guid OwnerId { get; set; }
    public Vector2 PositionOffset { get; } = new Vector2(0.5f - UnityEngine.Random.value, .5f - UnityEngine.Random.value);

    public string EnteredLocation;
    public PathModel CityPath;

    /// <summary>
    /// The index of the path node we are current moving towards
    /// </summary>
    public int CurrentPathIndex;
    public float MoveSpeed;

    public event Action<MapMovementModel> ReachedPathEnd;

    public bool AtPathEnd => CityPath.Path == null || CurrentPathIndex >= CityPath.Path.Count;

    Guid IIdentifiable.Id => OwnerId;

    public void OnReachedPathEnd()
    {
        ReachedPathEnd?.Invoke(this);
        ReachedPathEnd = null;
        CityPath = null;
    }
}
