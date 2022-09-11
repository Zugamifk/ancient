using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalDefense.ViewModel
{
    public interface IEnemyModel : IIdentifiable, IKeyHolder
    {
        Vector3 Position { get; }
    }
}
