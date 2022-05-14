using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapModel
{
    ICityGraph CityGraph { get; }
    IIdentifiableLookup<IBuildingModel> Buildings { get; }
    IMapGridModel Grid { get; }
}
