using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapModel : IMapModel
{
    public CityGraph Graph = new CityGraph();
    public IdentifiableCollection<BuildingModel> Buildings = new IdentifiableCollection<BuildingModel>();
    public MapGridModel Grid = new MapGridModel();
    public BuildingModel GetBuilding(string key) => Buildings.GetItem(key);

    #region IMapModel
    ICityGraph IMapModel.CityGraph => Graph;
    IEnumerable<IBuildingModel> IMapModel.Buildings => Buildings.AllItems;
    IMapGridModel IMapModel.Grid => Grid;
    IBuildingModel IMapModel.GetBuilding(string name) => GetBuilding(name);
    #endregion
}
