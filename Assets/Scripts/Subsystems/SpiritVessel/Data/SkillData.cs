using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.Data
{
    public class SkillData : ScriptableObject
    {
        public Sprite Icon;
        public string Description;
        public SkillData[] Required;
        public SkillData[] Unlocked;
    }
}
