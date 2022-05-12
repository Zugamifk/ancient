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
    IIdentifiableLookup<IBuildingModel> IMapModel.Buildings => Buildings;
    IMapGridModel IMapModel.Grid => Grid;
    ITileMapTransformer _tileMapTransformer;
    ITileMapTransformer IMapModel.TileMapTransformer => _tileMapTransformer;
    void IMapModel.SetTileMapTransformer(ITileMapTransformer transformer)
    {
        _tileMapTransformer = transformer;
    }
    #endregion
}
