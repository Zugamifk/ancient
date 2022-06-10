using Map.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace City.ViewModel
{
    public interface ICityModel 
    {
        ICityGraph CityGraph { get; }
        IIdentifiableLookup<IBuildingModel> Buildings { get; }
        IMapModel Map { get; }
    }
}
