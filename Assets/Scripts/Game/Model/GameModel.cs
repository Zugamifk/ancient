using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : IGameModel
{
    public MapModel MapModel = new MapModel();
    public TimeModel TimeModel = new TimeModel();
    public List<AgentModel> Agents = new List<AgentModel>();

    #region IGameModel
    IMapModel IGameModel.Map => MapModel;
    ITimeModel IGameModel.Time => TimeModel;
    IReadOnlyList<IAgentModel> IGameModel.Agents => Agents;
    #endregion

}
