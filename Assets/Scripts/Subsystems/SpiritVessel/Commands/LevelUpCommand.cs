using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.Model;
using SpiritVessel.Data;

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

            spiritvessel.Level++;

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
