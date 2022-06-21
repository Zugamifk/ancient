using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.Data
{
    public class AttackData : ScriptableObject, IPrefabReference
    {
        [field:SerializeField]
        public string Name { get; set; }

        [field:SerializeField]
        public GameObject Prefab { get; set; }
    }
}
