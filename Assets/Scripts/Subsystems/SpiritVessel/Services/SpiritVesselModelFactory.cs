using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.Model;
using SpiritVessel.Data;

namespace SpiritVessel.Services
{
    public static class SpiritVesselModelFactory
    {
        [RuntimeInitializeOnLoadMethod]
        static void RegisterSpiritVesselModelFactory()
        {
            ModelFactory.RegisterFactory<SpiritVesselDeskItemData>(MakeSpiritVesselModelFromData);
        }

        static ItemModel MakeSpiritVesselModelFromData(ItemData data)
        {
            return new SpiritVesselModel();
        }
    }
}
