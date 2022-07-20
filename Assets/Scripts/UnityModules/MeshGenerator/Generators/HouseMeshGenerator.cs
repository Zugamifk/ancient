using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class HouseGenerator : IGeometryGenerator
    {
        public class GeometryData : ScriptableObject
        {
            public float Rotation;

            public Vector2 FloorDimensions;
            public float FloorThickness;

            public float WallInset = 1;
            public float Height = 3;

            public float RoofPeak = 2;
            public float EavesLength = 1;

            [System.Serializable]
            public class WallData
            {
                public float DoorPosition = .5f;
                public float DoorWidth = 1;
                public float DoorHeight = 2;
            }
            public WallData[] Walls;

            public static GeometryData Instance;
            private void OnEnable()
            {
                Walls = new GeometryData.WallData[4];
                for (int i = 0; i < 4; i++)
                {
                    Walls[i] = new();
                }

                Instance = this;
            }
        }

        CubeGenerator _cubeGenerator = new();

        public GeometryData Data => _data;

        static GeometryData _data => GeometryData.Instance;

        static HouseGenerator()
        {
            if(_data==null)
            {
                ScriptableObject.CreateInstance<GeometryData>();
                _data.hideFlags = HideFlags.HideAndDontSave;
            }
        }

        public void Generate(MeshBuilder builder, Matrix4x4 matrix)
        {
            throw new System.NotImplementedException();
        }
    }
}
