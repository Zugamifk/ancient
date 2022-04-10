using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapModel
{
    ICityGraph CityGraph { get; }
    IReadOnlyList<IBuildingModel> Buildings { get; }
    IMapGridModel Grid { get; }
}
