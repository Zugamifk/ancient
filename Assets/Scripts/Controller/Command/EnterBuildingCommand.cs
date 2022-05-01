using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBuildingCommand : ICommand
{
    string _buildingName;
    string _characterName;

    BuildingModel _building;
    CharacterModel _character;

    public EnterBuildingCommand(string agentName, string buildingName)
    {
        _buildingName = buildingName;
        _characterName = agentName;
    }

    public void Execute(GameController controller)
    {
        _building = controller.Model.MapModel.GetBuilding(_buildingName);
        var destinationPosition = _building.Position;
        _character = controller.Model.Characters.GetItem(_characterName);
        var path = controller.MapController.PathFinder.GetDirectPath(Vector2Int.FloorToInt(_character.Movement.WorldPosition), Vector2Int.FloorToInt(destinationPosition), controller.Model.MapModel.Grid);
        _character.Movement.CityPath = path;
        _character.Movement.ReachedPathEnd += Enterbuilding;
    }

    void Enterbuilding(object sender, Vector2Int _)
    {
        _building.Agents.Add(_characterName);
        _character.Movement.EnteredLocation = _buildingName;
    }
}
