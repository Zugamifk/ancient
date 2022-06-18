using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.Model;
using SpiritVessel.Commands;

namespace SpiritVessel.Test
{
    public class SpiritVesselTest : MonoBehaviour
    {
        void Start()
        {
            Game.MutableModel.CreateModel<SpiritVesselModel>();
            Game.Do(new LoadMapDataCommand(Game.MutableModel.GetModel<SpiritVesselModel>().MapModel));
            Game.Do(new GenerateSpiritVesselMapCommand());
        }
    }
}
