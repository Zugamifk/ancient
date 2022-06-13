using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map.Model;

namespace City.Model
{
    public class MutableCityMapHandle : IMutableMapHandle
    {
        public MapModel Map => Game.MutableModel.GetModel<CityModel>().MapModel;
    }
}
