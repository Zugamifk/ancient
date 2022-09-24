using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalDefense.Data
{
    public class EndPortalMeshGeneratorData : ScriptableObject
    {
        public float Height = 2;
        public float ColumnSpacing = .5f;
        public float ColumnSize = .1f;
        public float RoofThickness = 0.05f;
    }
}