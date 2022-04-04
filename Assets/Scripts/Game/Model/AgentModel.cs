using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentModel : IAgentModel
{
    public string Name;
    public Vector2 WorldPosition;
    public CityPath Path;

    #region IAgentModel
    string IAgentModel.Name => Name;
    #endregion
}
