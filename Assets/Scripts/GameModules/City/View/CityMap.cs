using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using City.Commands;
using Input;

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
        }
    }
}