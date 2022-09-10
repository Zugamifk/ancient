using PortalDefense.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.Data;

namespace PortalDefense.Services
{
    public class MapGenerator
    {
        public Vector2Int Start, End;

        public void GenerateMap(MapModel model)
        {
            FillEmptyMap(model);
            GeneratePath(model);
        }

        void FillEmptyMap(MapModel model)
        {
            var data = DataService.GetData<PortalDefenseData>();
            var w = data.Dimensions.x;
            var h = data.Dimensions.y;
            for (int x = -w / 2; x <= w / 2; x++)
            {
                for (int y = -h / 2; y <= h / 2; y++)
                {
                    model.TileMap[new Vector2Int(x, y)] = new TileModel()
                    {
                        HasPath = false,
                        Height = 1
                    };
                }
            }

            model.Bounds = new BoundsInt(-w / 2, -h / 2, 0, w, h, 1);
        }

        void GeneratePath(MapModel model)
        {
            int xd = (int)Mathf.Sign(End.x - Start.x);
            int yd = (int)Mathf.Sign(End.y - Start.y);
            for (int x = Start.x; x != End.x + xd; x += xd)
            {
                for (int y = Start.y; y != End.y + yd; y += yd)
                {
                    model.TileMap[new Vector2Int(x, y)].HasPath = true;
                }
            }
        }
    }
}
