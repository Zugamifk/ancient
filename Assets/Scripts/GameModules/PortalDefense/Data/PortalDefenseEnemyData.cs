using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalDefense.Data
{
    public class PortalDefenseEnemyData : ScriptableObject, IKeyHolder
    {
        [SerializeField] string _key;
        public string Key => _key;
        public float MoveSpeed;
    }
}
