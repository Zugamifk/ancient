using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController
{
    GameModel _model = new GameModel();
    public IGameModel Model => _model;

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
}
