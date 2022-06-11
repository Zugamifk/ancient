using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map.View;
using Map.ViewModel;
using Map.Commands;
using City.Commands;

namespace City.View
{
    public class CityMap : MonoBehaviour
    {
        [SerializeField]
        TileMapper _tileMapper;
        [SerializeField]
        MapInputHandler _inputHandler;

        private void Start()
        {
            _tileMapper.SetMapHandle(new CityMapHandle());
            _inputHandler.CommandFactory = new CityCommandFactory();
        }
    }
}