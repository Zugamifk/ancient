using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.Model;
using Model;

namespace SpiritVessel.Commands
{
    public class GainExperienceCommand : ICommand
    {
        int _xp;

        public GainExperienceCommand(int xp) => _xp = xp;

        public void Execute(GameModel model)
        {
            var spiritvessel = model.GetModel<SpiritVesselModel>();
            spiritvessel.Experience += _xp;

            if(spiritvessel.Experience >= spiritvessel.ExperienceNeeded)
            {
                Game.Do(new LevelUpCommand());
            }
        }
    }
}
