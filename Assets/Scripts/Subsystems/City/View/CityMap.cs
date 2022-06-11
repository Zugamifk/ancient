using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map.View;
using Map.ViewModel;
using Map.Commands;

namespace City.View
{
    public class CityMap : MonoBehaviour
    {
        [SerializeField]
        TileMapper _tileMapper;

        private void Start()
        {
            _tileMapper.SetMapHandle(new CityMapHandle());
        }
    }
}