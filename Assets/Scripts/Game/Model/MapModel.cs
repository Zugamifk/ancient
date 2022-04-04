using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapModel : IMapModel
{
    public CityGraph Graph = new CityGraph();
    public List<BuildingModel> Buildings = new List<BuildingModel>();

    #region IMapModel
    ICityGraph IMapModel.CityGraph => Graph;
    IReadOnlyList<IBuildingModel> IMapModel.Buildings => Buildings;
    #endregion
}
