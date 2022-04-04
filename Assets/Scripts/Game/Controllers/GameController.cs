using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController
{
    TimeController _timeController = new TimeController();

    GameModel _model = new GameModel();
    public IGameModel Model => _model;

    public void Frameupdate(float deltaTime)
    {
        _timeController.UpdateTimeModel(_model.TimeModel, deltaTime);
    }

    public void AddBuilding(string name, Vector2Int position)
    {
        var building = new BuildingModel()
        {
            Name = name,
            Position = position
        };
        _model.MapModel.Buildings.Add(building);
        _model.MapModel.Graph.AddNode(building);
    }

    public void BuildRoad(string startName, string endName)
    {
        var start = _model.MapModel.Buildings.First(b => b.Name == startName);
        var end = _model.MapModel.Buildings.First(b => b.Name == endName);
        _model.MapModel.Graph.Connect(start, end);
    }

    public void AddAgent(string name)
    {
        var agent = new AgentModel()
        {
            Name = name
        };
        _model.Agents.Add(agent);
    }
}
