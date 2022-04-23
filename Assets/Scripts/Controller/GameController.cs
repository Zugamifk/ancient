using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : IGameInitializer, ICommandService
{
    UnityLifecycleController _lifecycleController;
    UpdateableGameObjectRegistry _updateableGameObjectRegistry;
    TimeController _timeController = new TimeController();
    AgentController _agentController = new AgentController();
    public MapController MapController { get; }
    NarrativeController _narrativeController;
    TextBookController _bookController = new TextBookController();
    public DeskController DeskController { get; }

    public readonly AgentCollection AgentCollection;
    BookCollection _bookCollection;

    public readonly GameModel Model = new GameModel();

    Queue<ICommand> _commandQueue = new Queue<ICommand>();

    public GameController(UnityLifecycleController lifeCycleController, UpdateableGameObjectRegistry updateableRegistry, AgentCollection agentCollection, TileDataCollection tileCollection, BuildingCollection buildingCollection, MapData mapData, NarrativeCollection narrativeCollection, DeskItemCollection deskItemCollection, BookCollection bookCollection)
    {
        _lifecycleController = lifeCycleController;
        _lifecycleController.OnUpdate += Update;
        _updateableGameObjectRegistry = updateableRegistry;

        AgentCollection = agentCollection;
        MapController = new MapController(this, tileCollection, buildingCollection, mapData);
        MapController.InitializeModel(Model.MapModel);
        _narrativeController = new NarrativeController(narrativeCollection, this);
        DeskController = new DeskController(deskItemCollection);
        _bookCollection = bookCollection;

        Model.WorkBook = _bookController.CreateModel((TextBookData)_bookCollection.GetBook("test"));
        Model.Cheats = new CheatController()
        {
            Model = Model,
            MapController = MapController
        };
    }

    void Update()
    {
        while (_commandQueue.Count > 0)
        {
            _commandQueue.Dequeue().Execute(this);
        }

        var deltaTime = Time.deltaTime;

        _timeController.Update(Model.TimeModel, deltaTime);
        foreach (var a in Model.Agents.Values)
        {
            _agentController.Update(a, Model);
        }

        foreach (var n in Model.Narratives.Values)
        {
            _narrativeController.Update(n, Model);
        }

        foreach (var updateable in _updateableGameObjectRegistry.Updateables)
        {
            updateable.UpdateModel(Model);
        }
    }

    #region IGameInitializer
    void IGameInitializer.StartNarrative(string name)
    {
        _narrativeController.StartNarrative(name, Model);
    }
    void IGameInitializer.AddBuilding(string name, Vector2Int position)
    {
        MapController.AddBuilding(Model.MapModel, name, position);
    }

    void IGameInitializer.BuildRoad(string startName, string endName)
    {
        MapController.BuildRoad(Model.MapModel, startName, endName);
    }
    #endregion

    #region ICommandService

    void ICommandService.DoCommand(ICommand command)
    {
        _commandQueue.Enqueue(command);
    }
    #endregion

    #region Helpers
    public Vector2 ParsePosition(string position)
    {
        Vector2 spawnPosition;
        if (position.Contains(","))
        {
            var split = position.Split(",");
            spawnPosition = new Vector2Int(int.Parse(split[0].Trim()), int.Parse(split[0].Trim()));
        }
        else
        {
            var b = Model.MapModel.GetBuilding(position);
            spawnPosition = b.Position;
        }
        return spawnPosition;
    }
    #endregion
}
