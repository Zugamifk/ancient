using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapModel
{
    public ICityGraph CityGraph { get; }
    public IReadOnlyList<IBuildingModel> Buildings { get; }
}
