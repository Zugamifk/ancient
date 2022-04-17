using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AgentModel : IAgentModel
{
    public string Name;
    public Vector2 WorldPosition;
    public CityPath CityPath;
    /// <summary>
    /// The index of the path node we are current moving towards
    /// </summary>
    public int CurrentPathIndex;
    public float MoveSpeed;

    public event EventHandler<Vector2Int> ReachedPathEnd;

    public bool AtPathEnd => CityPath.Path == null || CurrentPathIndex >= CityPath.Path.Count;

    public void OnReachedPathEnd()
    {
        ReachedPathEnd?.Invoke(this, CityPath.Path.Last());
        ReachedPathEnd = null;
    }

    #region IAgentModel
    string IAgentModel.Name => Name;
    Vector2 IAgentModel.WorldPosition => WorldPosition;
    #endregion
}
