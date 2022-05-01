using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementModel
{
    // live data
    public Vector2 WorldPosition { get; set; }
    public string EnteredLocation;
    public CityPath CityPath;

    /// <summary>
    /// The index of the path node we are current moving towards
    /// </summary>
    public int CurrentPathIndex;
    public float MoveSpeed;

    public event EventHandler<Vector2Int> ReachedPathEnd;

    public bool AtPathEnd => CityPath.Path == null || CurrentPathIndex >= CityPath.Path.Count;
    public bool IsVisibleOnMap => string.IsNullOrEmpty(EnteredLocation);

    public void OnReachedPathEnd()
    {
        ReachedPathEnd?.Invoke(this, CityPath.Path.Last());
        ReachedPathEnd = null;
        CityPath = null;
    }
}
