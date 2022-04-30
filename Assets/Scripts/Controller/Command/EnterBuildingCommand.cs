using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBuildingCommand : ICommand
{
    string _buildingName;
    string _agentName;

    BuildingModel _building;
    CharacterModel _agent;

    public EnterBuildingCommand(string agentName, string buildingName)
    {
        _buildingName = buildingName;
        _agentName = agentName;
    }

    public void Execute(GameController controller)
    {
        _building = controller.Model.MapModel.GetBuilding(_buildingName);
        var destinationPosition = _building.Position;
        _agent = controller.Model.Characters[_agentName];
        var path = controller.MapController.PathFinder.GetDirectPath(Vector2Int.FloorToInt(_agent.Movement.WorldPosition), Vector2Int.FloorToInt(destinationPosition), controller.Model.MapModel.Grid);
        _agent.Movement.CityPath = path;
        _agent.Movement.ReachedPathEnd += Enterbuilding;
    }

    void Enterbuilding(object sender, Vector2Int _)
    {
        _building.Agents.Add(_agentName);
        _agent.Movement.EnteredLocation = _buildingName;
    }
}
