using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;
using PortalDefense.ViewModel;

namespace PortalDefense.View
{
    public class Map : MonoBehaviour
    {
        Guid _mapGuid;

        private void Update()
        {
            var portalGame = Game.Model.GetModel<IPortalDefenseModel>();
            var map = portalGame.Map;
            if (_mapGuid != map.Id)
            {
                UpdateMap(map);
            }
        }

        void UpdateMap(ViewModel.IMapModel map)
        {
            _mapGuid = map.Id;
        }
    }
}
