using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController
{
    TimeController _timeController = new TimeController();
    AgentController _agentController = new AgentController();
    MapController _mapController = new MapController();

    AgentCollection _agentCollection;

    GameModel _model = new GameModel();
    public IGameModel Model => _model;

    public GameController(AgentCollection agentCollection)
    {
        _agentCollection = agentCollection;
    }

    public void Frameupdate(float deltaTime)
    {
        _timeController.UpdateTimeModel(_model.TimeModel, deltaTime);
        foreach (var a in _model.Agents.Values)
        {
            _agentController.FrameUpdate(a, deltaTime);
        }
    }

    public void InitializeMap(MapData data)
    {
        _mapController.InitializeModel(_model.MapModel, data.Dimensions, data.DefaultTile);
    }

    public void AddBuilding(string name, Vector2Int position)
    {
        _mapController.AddBuilding(_model.MapModel, name, position);
    }

    public void BuildRoad(string startName, string endName)
    {
        _mapController.BuildRoad(_model.MapModel, startName, endName);
    }

    public void AddAgent(string name)
    {
        var data = _agentCollection.GetAgent(name);
        var agent = new AgentModel()
        {
            Name = name,
            MoveSpeed = data.MoveSpeed
        };
        _model.Agents.Add(name, agent);
    }

    public void SetAgentPath(string name, string start, string end)
    {
        var startPoint = _model.MapModel.Buildings.First(b => b.Name == start);
        var endPoint = _model.MapModel.Buildings.First(b => b.Name == end);
        var path = new CityPath() { Start = startPoint, End = endPoint };
        var agent = _model.Agents[name];
        agent.Path = path;
    }
}
