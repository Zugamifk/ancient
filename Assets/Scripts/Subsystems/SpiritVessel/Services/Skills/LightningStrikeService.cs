using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.Model;
using SpiritVessel.Data;

namespace SpiritVessel.Services
{
    public class LightningStrikeService
    {
        public void AcquireSkill(LightningSkillModel model, string skillKey)
        {
            var skills = DataService.GetData<SpiritVesselSkillCollection>();
            var skillData = skills.GetData(skillKey);
            switch (skillKey)
            {
                case Skill.Lightning:
                    GainLightning(model);
                    break;
                default:
                    break;
            }
        }

        void GainLightning(LightningSkillModel model)
        {
            model.Owned = true;
            model.CoolDown = 1;

            var cloud = new LightningSkillCloudModel();
            cloud.Position = 5 * Random.insideUnitCircle;
            cloud.Radius = 2;
            model.Clouds.AddItem(cloud);
        }
    }
}
