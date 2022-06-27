using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.Data
{
    public class SkillData : ScriptableObject, IKeyHolder
    {
        public string Key;
        public string Name;
        public Sprite Icon;
        public string Description;
        public SkillData[] Required;
        public SkillData[] Unlocked;

        string IKeyHolder.Key => Key;
    }
}