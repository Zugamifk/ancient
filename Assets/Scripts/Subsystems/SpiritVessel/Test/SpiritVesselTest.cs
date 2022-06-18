using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.Model;
using SpiritVessel.Commands;
using SpiritVessel.ViewModel;

namespace SpiritVessel.Test
{
    public class SpiritVesselTest : MonoBehaviour
    {
        void Start()
        {
            Game.Do(new CreateSpiritVesselModelCommand());
        }
    }
}
