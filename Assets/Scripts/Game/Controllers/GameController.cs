using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController
{
    TimeController _timeController = new TimeController();
    AgentController _agentController = new AgentController();
    MapController _mapController;

    AgentCollection _agentCollection;

    GameModel _model = new GameModel();
    public IGameModel Model => _model;

    public GameController(AgentCollection agentCollection, TileDataCollection tileCollection, MapData mapData)
    {
        _agentCollection = agentCollection;
        _mapController = new MapController(tileCollection, mapData);
        _mapController.InitializeModel(_model.MapModel);
    }

    public void Frameupdate(float deltaTime)
    {
        _timeController.UpdateTimeModel(_model.TimeModel, deltaTime);
        foreach (var a in _model.Agents.Values)
        {
            _agentController.FrameUpdate(a, deltaTime);
        }
    }

    public void AddBuilding(string name, Vector2Int position)
    {
        _mapController.AddBuilding(_model.MapModel, name, position);
    }

    public void BuildRoad(string startName, string endName)
    {
        _mapController.BuildRoad(_model.MapModel, startName, endName);
    }

    public void AddAgent(string name, Vector2 position)
    {
        var data = _agentCollection.GetAgent(name);
        var agent = new AgentModel()
        {
            Name = name,
            MoveSpeed = data.MoveSpeed,
            WorldPosition = position
        };
        _model.Agents.Add(name, agent);
    }

    public void WalkToPosition(string name, Vector2 destination)
    {
        var startPoint = _model.Agents[name].WorldPosition;
        var endPoint = destination;
        var path = _mapController.GetPath(Vector2Int.FloorToInt(startPoint),Vector2Int.FloorToInt(endPoint), _model.MapModel.Grid);
        var agent = _model.Agents[name];
        agent.CityPath = path;
    }
}
