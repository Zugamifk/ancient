using Map.View;
using Map.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace City.View
{
    public class CityMapHandle : IMapHandle
    {
        public IMapModel Map => Game.Model.City.Map;
    }
}
