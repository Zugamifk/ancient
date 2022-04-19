using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : INarrativeEventHandler, IGameInitializer
{
    UnityLifecycleController _lifecycleController;
    UpdateableGameObjectRegistry _updateableGameObjectRegistry;
    TimeController _timeController = new TimeController();
    AgentController _agentController = new AgentController();
    MapController _mapController;
    NarrativeController _narrativeController;
    BookController _bookController = new BookController();
    DeskController _deskController;

    AgentCollection _agentCollection;

    GameModel _model = new GameModel();
    public IGameModel Model => _model;

    public GameController(UnityLifecycleController lifeCycleController, UpdateableGameObjectRegistry updateableRegistry, AgentCollection agentCollection, TileDataCollection tileCollection, MapData mapData, NarrativeCollection narrativeCollection, DeskItemCollection deskItemCollection)
    {
        _lifecycleController = lifeCycleController;
        _lifecycleController.OnUpdate += Update;
        _updateableGameObjectRegistry = updateableRegistry;

        _agentCollection = agentCollection;
        _mapController = new MapController(tileCollection, mapData);
        _mapController.InitializeModel(_model.MapModel);
        _narrativeController = new NarrativeController(narrativeCollection, this);
        _deskController = new DeskController(deskItemCollection);

        _model.WorkBook = _bookController.CreateBookModel();
        _model.Cheats = new CheatController()
        {
            Model = _model,
            MapController = _mapController
        };
    }

    void Update()
    {
        var deltaTime = Time.deltaTime;

        _timeController.Update(_model.TimeModel, deltaTime);
        foreach (var a in _model.Agents.Values)
        {
            _agentController.Update(a, _model);
        }

        foreach (var n in _model.Narratives.Values)
        {
            _narrativeController.Update(n, _model);
        }

        foreach (var updateable in _updateableGameObjectRegistry.Updateables)
        {
            updateable.UpdateModel(_model);
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

    void INarrativeEventHandler.WalkToPosition(string name, string destination, EventHandler<Vector2Int> reachedPathEnd)
    {
        var destinationPosition = ParsePosition(destination);
        var startPoint = _model.Agents[name].WorldPosition;
        var endPoint = destinationPosition;
        var path = _mapController.GetPath(Vector2Int.FloorToInt(startPoint), Vector2Int.FloorToInt(endPoint), _model.MapModel.Grid);
        var agent = _model.Agents[name];
        agent.CityPath = path;
        agent.ReachedPathEnd += reachedPathEnd;
    }

    void INarrativeEventHandler.SpawnDeskItem(string name)
    {
        _deskController.AddItem(name, _model.Desk);
    }

    void INarrativeEventHandler.ReceievePackage(string name)
    {

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
