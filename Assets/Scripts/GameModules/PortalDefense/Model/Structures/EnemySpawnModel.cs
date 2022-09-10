using PortalDefense.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalDefense.Model
{
    public class EnemySpawnModel : IEnemySpawnModel
    {
        public string Key => "EndPortal";

        public List<Guid> SpawnQueue = new();
        IEnumerable<Guid> IEnemySpawnModel.SpawnQueue => SpawnQueue;

    }
}
