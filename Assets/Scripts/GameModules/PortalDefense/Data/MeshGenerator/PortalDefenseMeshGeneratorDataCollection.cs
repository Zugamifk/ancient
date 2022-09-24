using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalDefense.Data
{
    public class PortalDefenseMeshGeneratorDataCollection : ScriptableObject, IRegisteredData
    {
        public EndPortalMeshGeneratorData EndPortal;
        public EnemyMeshGeneratorData Enemy;
        public ArrowTowerMeshGeneratorData ArrowTower;
        public CardFrameMeshGeneratorData CardFrame;
    }
}