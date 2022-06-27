using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.Data
{
    public class LightningSkillDataCollection : ScriptableObject
    {
        public SkillData First;
        public SkillData[] FrequencyIncreases;
        public SkillData[] AreaOfEffectIncreases;
        public SkillData[] ChainingIncreases;
        public SkillData[] RainIncreases;
        public SkillData[] CloudIncreases;
        public SkillData Final;
    }
}
