using PortalDefense.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalDefense.Services
{
    public class MapGenerator
    {
        public void GenerateMap(MapModel model)
        {
            for(int x = -25; x <= 25;x++)
            {
                for (int y = -25; y <= 25; y++)
                {
                    model.TileMap[new Vector2Int(x, y)] = new TileModel()
                    {
                        Height = Random.Range(1,5)
                    };
                }
            }

            model.Bounds = new BoundsInt(-25, -25, 0, 50, 50, 1);
        }
    }
}
