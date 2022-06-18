using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;

namespace SpiritVessel.View
{
    public class SpiritVesselMap : MonoBehaviour
    {
        [SerializeField]
        TileMapper _tileMapper;
        [SerializeField]
        MapInputHandler _inputHandler;

        private void Start()
        {
            //_inputHandler.CommandFactory = new CityCommandFactory();
        }
    }
}
