using City.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace City.Data
{
    public class BuildingCollection : SimplePrefabLookup<IBuildingModel, BuildingData>
    {
        public BuildingData[] Buildings;
        protected override IEnumerable<BuildingData> PrefabReferences => Buildings;
    }
}