using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;

namespace SpiritVessel.Model
{
    public class SpiritVesselModel : ItemModel, ISpiritVesselModel, IExaminable, IMapUser
    {
        public MapModel MapModel { get; } = new("SpiritVessel");
        public float OutsideRadius { get; set; }

        public bool IsExamining { get; set; }
        public IdentifiableCollection<AttackModel> Attacks { get; } = new();
        public IdentifiableCollection<HitpointsHealthModel> HitpointModels { get; } = new();

        public int Level { get; set; }
        public LevelUpModel LevelUp { get; set; }
        public int Experience { get; set; }
        public int ExperienceNeeded { get; set; }
        public HashSet<string> AcquiredSkills { get; set; } = new();
        public HashSet<string> AvailableSkills { get; set; } = new();

        public LightningSkillModel LightningSkill { get; set; } = new();

        #region ISpiritVesselModel 
        IMapModel ISpiritVesselModel.Map => MapModel;
        ILevelUpModel ISpiritVesselModel.LevelUp => LevelUp;
        IIdentifiableLookup<IAttackModel> ISpiritVesselModel.Attacks => Attacks;
        IIdentifiableLookup<IHitpointsHealthModel> ISpiritVesselModel.HitpointModels => HitpointModels;
        ILightningSkillModel ISpiritVesselModel.LightningSkill => LightningSkill;
        #endregion
    }
}