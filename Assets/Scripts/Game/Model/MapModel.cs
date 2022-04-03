using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapModel : IMapModel
{
    public CityGraph Graph = new CityGraph();
    public List<BuildingModel> Buildings = new List<BuildingModel>();

    IReadOnlyList<IBuildingModel> IMapModel.Buildings => Buildings;
}
