using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;

namespace SpiritVessel.Model
{
    public class SpiritVesselModel : ItemModel, ISpiritVesselModel, IExaminable, IMapUser
    {
        public MapModel MapModel { get; } = new();
        public bool IsExamining { get; set; }

        #region ISpiritVesselModel 
        IMapModel ISpiritVesselModel.Map => MapModel;
        #endregion
    }
}