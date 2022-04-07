using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController
{
    TimeController _timeController = new TimeController();
    AgentController _agentController = new AgentController();
    NarrativeController _narrativeController;

    AgentCollection _agentCollection;

    GameModel _model = new GameModel();
    public IGameModel Model => _model;

    public GameController(AgentCollection agentCollection, NarrativeCollection narrativeCollection)
    {
        _agentCollection = agentCollection;
        _narrativeController = new NarrativeController(narrativeCollection);
    }

    public void Frameupdate(float deltaTime)
    {
        _timeController.UpdateTimeModel(_model.TimeModel, deltaTime);
        foreach (var a in _model.Agents.Values)
        {
            _agentController.FrameUpdate(a, deltaTime);
        }
    }

    public void StartNarrative(string name, Queue<GameEvent> eventQueue)
    {
        _narrativeController.StartNarrative(name, eventQueue);
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
