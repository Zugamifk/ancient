using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapModel : IMapModel
{
    public CityGraph Graph = new CityGraph();
    public List<BuildingModel> Buildings = new List<BuildingModel>();
    public MapGridModel Grid = new MapGridModel();

    #region IMapModel
    ICityGraph IMapModel.CityGraph => Graph;
    IReadOnlyList<IBuildingModel> IMapModel.Buildings => Buildings;
    IMapGridModel IMapModel.Grid => Grid;
    IBuildingModel IMapModel.GetBuilding(string name) => Buildings.Find(b => b.Name == name);
    #endregion
}
