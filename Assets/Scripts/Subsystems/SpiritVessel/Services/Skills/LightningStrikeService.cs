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
            switch (skillKey)
            {
                case Skill.Lightning:
                    GainLightning(model);
                    break;
                case Skill.HighPotential:
                    GainHighPotential(model);
                    break;
                case Skill.ExtremePotential:
                    GainExtremePotential(model);
                    break;
                case Skill.CriticalPotential:
                    GainCriticalPotential(model);
                    break;
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
                case Skill.LightningPentagram:
                default:
                    throw new System.InvalidOperationException($"{skillKey} is not a recognized lightning skill!");
            }
        }

        void GainLightning(LightningSkillModel model)
        {
            model.Owned = true;
            model.MoveDirection = Random.insideUnitCircle.normalized;
            model.Speed = 1;

            model.CoolDown = 1;

            var cloud = new LightningSkillCloudModel();
            cloud.Position = 5 * Random.insideUnitCircle;
            cloud.Radius = 5;
            model.Clouds.AddItem(cloud);

            model.Chains = 5;
            model.ChainRadius = 3;
        }

        void GainHighPotential(LightningSkillModel model)
        {
            model.CoolDown *= 0.5f;
        }

        void GainExtremePotential(LightningSkillModel model)
        {
            model.CoolDown *= 0.5f;
        }

        void GainCriticalPotential(LightningSkillModel model)
        {
            model.CoolDown *= 0.5f;
        }

        void GainChainLightning(LightningSkillModel model)
        {
            model.Chains += 2;
        }
    }
}
