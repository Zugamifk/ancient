using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapModel
{
    ICityGraph CityGraph { get; }
    IEnumerable<IBuildingModel> Buildings { get; }
    IMapGridModel Grid { get; }

    public IBuildingModel GetBuilding(string name);
}
