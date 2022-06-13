using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.Model
{
    public class SpiritVesselModel : ItemModel, IExaminable
    {
        public bool IsExamining { get; set; }
    }
}