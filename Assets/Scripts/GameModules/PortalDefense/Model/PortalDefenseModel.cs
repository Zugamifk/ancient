using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.ViewModel;

namespace PortalDefense.Model
{
    public class PortalDefenseModel : IPortalDefenseModel
    {
        public MapModel Map { get; set; } = new();
        public IdentifiableCollection<EnemyModel> SpawnedEnemies = new();

        IMapModel IPortalDefenseModel.Map => Map;
    }
}
