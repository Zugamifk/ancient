using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;
using PortalDefense.ViewModel;

namespace PortalDefense.View
{
    public class PortalGameMap : MonoBehaviour
    {
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
            for(int x = map.Bounds.xMin;x<=map.Bounds.xMax;x++)
            {
                for (int y = map.Bounds.yMin; y <= map.Bounds.yMax; y++)
                {
                    var tile = Instantiate(_tilePrefab);
                    tile.transform.parent = transform;
                    tile.transform.position = new Vector3(x, 0, y);
                    tile.SetTile(map.GetTile(new Vector2Int(x, y)));
                }
            }

            _mapGuid = map.Id;
        }
    }
}
