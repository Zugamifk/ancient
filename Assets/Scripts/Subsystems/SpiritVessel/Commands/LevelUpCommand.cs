using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.Model;
using SpiritVessel.Data;
using System.Linq;

namespace SpiritVessel.Commands
{
    public class LevelUpCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            var spiritvessel = model.GetModel<SpiritVesselModel>();
            if(spiritvessel.Experience < spiritvessel.ExperienceNeeded)
            {
                throw new System.InvalidOperationException($"Can't level up! XP needed: {spiritvessel.ExperienceNeeded}, have {spiritvessel.Experience}");
            }

            spiritvessel.LevelUp = new();
            int max = 1000;
            while(max-- > 0 && spiritvessel.LevelUp.SkillOptions.Count < 3)
            {
                var skill = spiritvessel.AvailableSkills.ElementAt(Random.Range(0, spiritvessel.AvailableSkills.Count));
                if(!spiritvessel.LevelUp.SkillOptions.Contains(skill))
                {
                    spiritvessel.LevelUp.SkillOptions.Add(skill);
                }
            }

            var lastXp = spiritvessel.ExperienceNeeded;
            spiritvessel.Experience -= lastXp;

            var prog = DataService.GetData<SpiritVesselProgressionData>();
            if(spiritvessel.Level < prog.Levels.Length)
            {
                spiritvessel.ExperienceNeeded = prog.Levels[spiritvessel.Level].XpRequired;
            } else
            {
                spiritvessel.ExperienceNeeded += prog.Levels[^1].XpRequired;
            }
        }
    }
}
