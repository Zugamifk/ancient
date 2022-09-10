using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;
using PortalDefense.ViewModel;
using PortalDefense.Services;

namespace PortalDefense.View
{
    public class PortalGameMap : MonoBehaviour
    {
        class DefaultEdgeTile : ViewModel.ITileModel
        {
            public bool HasPath => false;
            public int Height => 1;
            public static readonly DefaultEdgeTile Instance = new();
        }

        [SerializeField]
        PortalGameTile _tilePrefab;

        Guid _mapGuid;

        private void Update()
        {
            var portalGame = Game.Model.GetModel<IPortalDefenseModel>();
            if (portalGame == null) return;

            var map = portalGame.Map;
            if (_mapGuid != map.Id)
            {
                UpdateMap(map);
            }
        }

        void UpdateMap(ViewModel.IMapModel map)
        {
            ViewModel.ITileModel left, top, right, bottom;

            for(int x = map.Bounds.xMin;x<=map.Bounds.xMax;x++)
            {
                for (int y = map.Bounds.yMin; y <= map.Bounds.yMax; y++)
                {
                    if (x > map.Bounds.xMin)
                    {
                        left = map.GetTile(new Vector2Int(x - 1, y));
                    } else left = DefaultEdgeTile.Instance;
                    if(x < map.Bounds.xMax)
                    {
                        right = map.GetTile(new Vector2Int(x + 1, y));
                    }
                    else right = DefaultEdgeTile.Instance;
                    if (y > map.Bounds.yMin)
                    {
                        bottom = map.GetTile(new Vector2Int(x, y - 1));
                    }
                    else bottom = DefaultEdgeTile.Instance;
                    if (y < map.Bounds.yMax)
                    {
                        top = map.GetTile(new Vector2Int(x, y + 1));
                    }
                    else top = DefaultEdgeTile.Instance;

                    var tile = Instantiate(_tilePrefab);
                    tile.transform.parent = transform;
                    tile.transform.position = new Vector3(x, 0, y);

                    var context = new MapMeshGenerator.TileContext()
                    {
                        LeftNeighbour = left,
                        TopNeighbour = top,
                        RightNeighbour = right,
                        BottomNeighbour = bottom
                    };
                    tile.SetTile(map.GetTile(new Vector2Int(x, y)), context);
                }
            }

            _mapGuid = map.Id;
        }
    }
}
