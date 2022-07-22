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

            public float BaseExtents = 1;
            public float Height = 3;

            public float RoofPeak = 2;
            public float EavesLength = 1;
            public float WindowHeight = 1;

            [System.Serializable]
            public class DoorData
            {
                public float Position = .5f;
                public Vector2 Dimensions = Vector2.one;
                public int Wall = 0;
            }

            [System.Serializable]
            public class WindowData
            {
                public float Position;
                public Vector2 Dimensions = Vector2.one;
            }

            [System.Serializable]
            public class WallData
            {
                public List<WindowData> Windows = new();
            }
            public List<WallData> Walls = new();

            public DoorData Door;

            public static GeometryData Instance;
            private void OnEnable()
            {
                if (Walls.Count != 4)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Walls.Add(new());
                    }
                }

                Instance = this;
            }
        }

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
            Debug.Log("Generating Mesh");
        }
    }
}
