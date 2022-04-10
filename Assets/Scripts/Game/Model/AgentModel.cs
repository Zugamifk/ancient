using System.Collections;
using System.Collections.Generic;
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

    public bool AtPathEnd => CityPath.Path == null || CurrentPathIndex >= CityPath.Path.Count;

    #region IAgentModel
    string IAgentModel.Name => Name;
    Vector2 IAgentModel.WorldPosition => WorldPosition;
    #endregion
}
