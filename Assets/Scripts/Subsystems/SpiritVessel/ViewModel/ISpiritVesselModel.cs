using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.ViewModel
{
    public interface ISpiritVesselModel : IRegisteredModel, IItemModel, IIsExamining
    {
        IMapModel Map { get; }
        IIdentifiableLookup<IAttackModel> Attacks { get; }
        int Level { get; }
        ILevelUpModel LevelUp { get; }
        int Experience { get; }
        int ExperienceNeeded { get; }
        
        ILightningSkillModel LightningSkill { get; }
    }
}