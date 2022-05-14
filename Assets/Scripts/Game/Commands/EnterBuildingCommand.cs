using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterBuildingCommand : ICommand
{
    static PathFinder _pathFinder = new PathFinder();
    string _buildingName;
    string _characterName;

    BuildingModel _building;
    CharacterModel _character;

    public EnterBuildingCommand(string agentName, string buildingName)
    {
        _buildingName = buildingName;
        _characterName = agentName;
    }

    public void Execute(GameModel model)
    {
        Debug.Log($"COMMAND: {_characterName} enters {_buildingName}");
        _building = model.MapModel.GetBuilding(_buildingName);
        var destinationPosition = _building.Position;
        _character = model.Characters.GetItem(_characterName);
        var path = _pathFinder.GetDirectPath(
            Vector2Int.FloorToInt(_character.Movement.WorldPosition), 
            Vector2Int.FloorToInt(destinationPosition), 
            model.MapModel.Grid);
        _character.Movement.CityPath = path;
        _character.Movement.ReachedPathEnd += Enterbuilding;
    }

    void Enterbuilding(MovementModel model)
    {
        _building.Agents.Add(_characterName);
        _character.Movement.EnteredLocation = _buildingName;
    }
}
