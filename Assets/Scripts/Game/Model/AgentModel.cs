using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentModel : IAgentModel
{
    public string Name;
    public Vector2 WorldPosition;
    public CityPath Path;
    public float MoveSpeed;

    #region IAgentModel
    string IAgentModel.Name => Name;
    Vector2 IAgentModel.WorldPosition => WorldPosition;
    #endregion
}
