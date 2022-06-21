using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;

namespace SpiritVessel.Model
{
    public class SpiritVesselModel : ItemModel, ISpiritVesselModel, IExaminable, IMapUser
    {
        public MapModel MapModel { get; } = new("SpiritVessel");
        public bool IsExamining { get; set; }
        public IdentifiableCollection<AttackModel> Attacks { get; } = new();

        #region ISpiritVesselModel 
        IMapModel ISpiritVesselModel.Map => MapModel;
        IIdentifiableLookup<IAttackModel> ISpiritVesselModel.Attacks => Attacks;
        #endregion
    }
}