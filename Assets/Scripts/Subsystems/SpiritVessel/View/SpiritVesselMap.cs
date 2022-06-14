using Map.View;
using Map.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;

namespace SpiritVessel.View
{
    public class SpiritVesselMap : MonoBehaviour
    {
        class MapHandle : IMapHandle
        {
            public IMapModel Map => Game.Model.GetModel<ISpiritVesselModel>().Map;
        }

        [SerializeField]
        TileMapper _tileMapper;
        [SerializeField]
        MapInputHandler _inputHandler;

        private void Start()
        {
            _tileMapper.SetMapHandle(new MapHandle());
            //_inputHandler.CommandFactory = new CityCommandFactory();
        }
    }
}
