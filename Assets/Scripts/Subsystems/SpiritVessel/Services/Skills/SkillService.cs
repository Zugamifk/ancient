using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.Model;
using SpiritVessel.Data;
using System.Linq;

namespace SpiritVessel.Services
{
    public class SkillService
    {
        public void AcquireSkill(SpiritVesselModel model, string skillKey)
        {
            var skills = DataService.GetData<SpiritVesselSkillCollection>();
            var skillData = skills.GetData(skillKey);
            if (skillData == null)
            {
                throw new System.InvalidOperationException($"No skill named \'{skillKey}\' available!!");
            }

            model.AcquiredSkills.Add(skillKey);
            model.AvailableSkills.Remove(skillKey);
            foreach (var unlocked in skillData.Unlocked)
            {
                if (unlocked.Required.All(req => model.AcquiredSkills.Contains(req.Key)))
                {
                    model.AvailableSkills.Add(unlocked.Key);
                }
            }

            ConfigureNewSkill(model, skillKey);
        }

        void ConfigureNewSkill(SpiritVesselModel model, string skillKey)
        {
            switch (skillKey)
            {

                case Skill.Lightning:
                case Skill.HighPotential:
                case Skill.ExtremePotential:
                case Skill.CriticalPotential:
                case Skill.ChainLightning:
                case Skill.DoubleChain:
                case Skill.CollateralShock:
                case Skill.HeavyBolt:
                case Skill.LightningBlast:
                case Skill.StaticShockField:
                case Skill.HeavyRain:
                case Skill.Downpour:
                case Skill.Cumulonimbus:
                case Skill.Supercell:
                case Skill.Tempest:
                    break;
                case Skill.LightningPentagram:
                    {
                        var srv = new LightningStrikeService();
                        srv.AcquireSkill(model.LightningSkill, skillKey);
                    }
                    break;
                default:
                    throw new System.InvalidOperationException($"{skillKey} is not a recognized skill!");
            }
        }
    }
}
