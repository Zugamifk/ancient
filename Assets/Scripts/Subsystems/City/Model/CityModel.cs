using City.ViewModel;
using Map.Model;
using Map.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace City.Model
{
    public class CityModel : ICityModel
    {
        public MapModel MapModel = new();
        public CityGraph Graph = new CityGraph();
        public IdentifiableCollection<BuildingModel> Buildings = new IdentifiableCollection<BuildingModel>();

        IMapModel ICityModel.Map => MapModel;
        ICityGraph ICityModel.CityGraph => Graph;
        IIdentifiableLookup<IBuildingModel> ICityModel.Buildings => Buildings;
    }
}
