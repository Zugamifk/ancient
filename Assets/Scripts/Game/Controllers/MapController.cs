using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController
{
    public void AddBuilding(MapModel model, string name, Vector2Int position)
    {
        var building = new BuildingModel()
        {
            Name = name,
            Position = position
        };
        model.Buildings.Add(building);
        //var entrance = new IntersectionGraphNode()
        //{
        //    Position = building.Position + 
        //}
        
    }

    //public void BuildRoad(string startName, string endName)
    //{
    //    var start = _model.MapModel.Buildings.First(b => b.Name == startName);
    //    var end = _model.MapModel.Buildings.First(b => b.Name == endName);
    //    _model.MapModel.Graph.Connect(start, end);
    //}
}
