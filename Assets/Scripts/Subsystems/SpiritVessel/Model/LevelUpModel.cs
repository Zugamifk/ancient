using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;

namespace SpiritVessel.Model
{
    public class LevelUpModel : ILevelUpModel
    {
        public List<string> SkillOptions = new();

        #region ILevelUpModel 
        IReadOnlyList<string> ILevelUpModel.SkillOptions => SkillOptions;
        #endregion
    }
}
