using City.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;
using Model;

namespace City.Model
{
    public class CityModel : ICityModel, IMapUser
    {
        public MapModel MapModel { get; } = new("City");
        public CityGraph Graph = new CityGraph();
        public IdentifiableCollection<BuildingModel> Buildings = new IdentifiableCollection<BuildingModel>();

        IMapModel ICityModel.Map => MapModel;
        ICityGraph ICityModel.CityGraph => Graph;
        IIdentifiableLookup<IBuildingModel> ICityModel.Buildings => Buildings;
    }
}
