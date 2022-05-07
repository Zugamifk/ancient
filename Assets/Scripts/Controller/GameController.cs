using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : ICommandService
{
    // Controllers
    UnityLifecycleController _lifecycleController;
    UpdateableGameObjectRegistry _updateableGameObjectRegistry;
    TimeController _timeController = new TimeController();
    CharacterController _characterController = new CharacterController();
    MovementController _movementController = new MovementController();
    public MapController MapController { get; }
    internal NarrativeController NarrativeController { get; }
    public ItemController ItemController { get; }
    public CharacterCollection CharacterCollection { get; }

    public TurretDefenseController TurretDefenseController { get; } 

    //state
    public GameModel Model { get; } = new GameModel();

    Queue<ICommand> _commandQueue = new Queue<ICommand>();

    public GameController(UnityLifecycleController lifeCycleController, UpdateableGameObjectRegistry updateableRegistry, CharacterCollection characterCollection, TileDataCollection tileCollection, BuildingCollection buildingCollection, MapData mapData, NarrativeCollection narrativeCollection, ItemCollection itemCollection, TurretDefenseData turretDefenseData)
    {
        _lifecycleController = lifeCycleController;
        _lifecycleController.OnUpdate += Update;
        _updateableGameObjectRegistry = updateableRegistry;

        CharacterCollection = characterCollection;
        MapController = new MapController(this, tileCollection, buildingCollection, mapData);
        MapController.InitializeModel(Model.MapModel);
        NarrativeController = new NarrativeController(narrativeCollection, this);
        ItemController = new ItemController(itemCollection);

        TurretDefenseController = new TurretDefenseController(this, turretDefenseData);

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
        foreach (var c in Model.Characters.AllItems)
        {
            _characterController.Update(c, Model);
        }

        foreach(var m in Model.MovementModels)
        {
            _movementController.Update(m, Model);
        }

        foreach (var n in Model.Narratives.Values)
        {
            NarrativeController.Update(n, Model);
        }

        TurretDefenseController.Update(Model);

        foreach (var updateable in _updateableGameObjectRegistry.Updateables)
        {
            updateable.UpdateFromModel(Model);
        }
    }

    #region ICommandService
    public void DoCommand(ICommand command)
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
            spawnPosition = b.EntrancePosition;
        }
        return spawnPosition;
    }
    #endregion
}
