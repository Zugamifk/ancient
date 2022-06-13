using Map.View;
using Map.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using City.ViewModel;

namespace City.View
{
    public class CityMapHandle : IMapHandle
    {
        public IMapModel Map => Game.Model.GetModel<ICityModel>().Map;
    }
}
