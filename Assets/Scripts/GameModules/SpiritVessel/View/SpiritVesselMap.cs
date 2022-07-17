using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;
using Input;

namespace SpiritVessel.View
{
    public class SpiritVesselMap : MonoBehaviour
    {
        [SerializeField]
        TileMapper _tileMapper;
        [SerializeField]
        MapInputHandler _inputHandler;

        private IEnumerator Start()
        {
            yield return new WaitUntil(() => Game.Model.GetModel<ISpiritVesselModel>() != null);
            _tileMapper.MapId = Game.Model.GetModel<ISpiritVesselModel>().Map.Id;
        }
    }
}
