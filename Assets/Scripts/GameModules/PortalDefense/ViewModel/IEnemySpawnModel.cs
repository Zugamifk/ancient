using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalDefense.ViewModel
{
    public interface IEnemySpawnModel : ITileStructure
    {
        IEnumerable<Guid> SpawnQueue { get; }
    }
}
