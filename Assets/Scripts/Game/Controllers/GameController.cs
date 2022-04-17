using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : INarrativeEventHandler, IGameInitializer, ICheatController
{
    TimeController _timeController = new TimeController();
    AgentController _agentController = new AgentController();
    MapController _mapController;
    NarrativeController _narrativeController;

    AgentCollection _agentCollection;

    GameModel _model = new GameModel();
    public IGameModel Model => _model;

    public GameController(AgentCollection agentCollection, TileDataCollection tileCollection, MapData mapData, NarrativeCollection narrativeCollection)
    {
        _agentCollection = agentCollection;
        _mapController = new MapController(tileCollection, mapData);
        _mapController.InitializeModel(_model.MapModel);
        _narrativeController = new NarrativeController(narrativeCollection, this);
    }

    public void Frameupdate(float deltaTime)
    {
        _timeController.UpdateTimeModel(_model.TimeModel, deltaTime);
        foreach (var a in _model.Agents.Values)
        {
            _agentController.FrameUpdate(a, deltaTime);
        }

        foreach(var n in _model.Narratives.Values)
        {
            _narrativeController.FrameUpdate(n, _model);
        }
    }

    #region IGameInitializer
    void IGameInitializer.StartNarrative(string name)
    {
        _narrativeController.StartNarrative(name, _model);
    }
    void IGameInitializer.AddBuilding(string name, Vector2Int position)
    {
        _mapController.AddBuilding(_model.MapModel, name, position);
    }

    void IGameInitializer.BuildRoad(string startName, string endName)
    {
        _mapController.BuildRoad(_model.MapModel, startName, endName);
    }
    #endregion

    #region ICheatController
    IGameModel ICheatController.GameModel => _model;
    void ICheatController.SetTile(int x, int y, string type)
    {
        _mapController.SetTile(_model.MapModel, x, y, type);
    }
    #endregion

    #region INarrativeEventHandler
    void INarrativeEventHandler.SpawnAgent(string name, string position)
    {
        var spawnPosition = ParsePosition(position);
        var data = _agentCollection.GetAgent(name);
        var agent = new AgentModel()
        {
            Name = name,
            MoveSpeed = data.MoveSpeed,
            WorldPosition = spawnPosition
        };
        _model.Agents.Add(name, agent);
    }

    void INarrativeEventHandler.WalkToPosition(string name, string destination)
    {
        var destinationPosition = ParsePosition(destination);
        var startPoint = _model.Agents[name].WorldPosition;
        var endPoint = destinationPosition;
        var path = _mapController.GetPath(Vector2Int.FloorToInt(startPoint), Vector2Int.FloorToInt(endPoint), _model.MapModel.Grid);
        var agent = _model.Agents[name];
        agent.CityPath = path;
    }

    Vector2 ParsePosition(string position)
    {
        Vector2 spawnPosition;
        if (position.Contains(","))
        {
            var split = position.Split(",");
            spawnPosition = new Vector2Int(int.Parse(split[0].Trim()), int.Parse(split[0].Trim()));
        }
        else
        {
            var b = Model.Map.GetBuilding(position);
            spawnPosition = b.Position;
        }
        return spawnPosition;
    }
    #endregion
}
