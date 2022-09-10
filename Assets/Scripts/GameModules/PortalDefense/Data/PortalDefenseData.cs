using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalDefense.Data
{
    public class PortalDefenseData : ScriptableObject, IRegisteredData
    {
        public Color GrassColor;
        public Color PathColor;
        public float RoadWidth;
        public Vector2Int Dimensions;
    }
}
