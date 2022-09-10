using PortalDefense.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.Data;

namespace PortalDefense.Services
{
    public class MapGenerator
    {
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
            var end = new PathNodeModel() { Position = new Vector2Int() };
            var start = new PathNodeModel() { Position = new Vector2Int(0, 10), Next = end };
            model.Paths.StartNode = start;
            model.Paths.EndNode = end;

            GenerateTilePaths(model);

            model.TileMap[end.Position].Structure = new EndPortalModel();
        }

        void GenerateTilePaths(MapModel model)
        {
            for (var start = model.Paths.StartNode; start != model.Paths.EndNode; start = start.Next)
            {
                GenerateNodePath(model, start.Position, start.Next.Position);
            }
        }

        void GenerateNodePath(MapModel model, Vector2Int start, Vector2Int end)
        {
            int xd = (int)Mathf.Sign(end.x - start.x);
            int yd = (int)Mathf.Sign(end.y - start.y);
            for (int x = start.x; x != end.x + xd; x += xd)
            {
                for (int y = start.y; y != end.y + yd; y += yd)
                {
                    model.TileMap[new Vector2Int(x, y)].HasPath = true;
                }
            }
        }
    }
}
