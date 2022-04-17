using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameModel : IGameModel
{
    public MapModel MapModel = new MapModel();
    public TimeModel TimeModel = new TimeModel();
    public Dictionary<string, AgentModel> Agents = new Dictionary<string, AgentModel>();
    public Dictionary<string, NarrativeModel> Narratives = new Dictionary<string, NarrativeModel>();

    #region IGameModel
    IMapModel IGameModel.Map => MapModel;
    ITimeModel IGameModel.Time => TimeModel;
    IEnumerable<IAgentModel> IGameModel.Agents => Agents.Values.Cast<IAgentModel>();
    #endregion

}
