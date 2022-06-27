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

        public int Level { get; set; }
        public int Experience { get; set; }
        public int ExperienceNeeded { get; set; }
        public IdentifiableCollection<SkillLevelModel> AcquiredSkills { get; set; } = new();

        public LightningSkillModel LightningSkill { get; set; } = new();

        #region ISpiritVesselModel 
        IMapModel ISpiritVesselModel.Map => MapModel;
        IIdentifiableLookup<IAttackModel> ISpiritVesselModel.Attacks => Attacks;
        ILightningSkillModel ISpiritVesselModel.LightningSkill => LightningSkill;
        #endregion
    }
}