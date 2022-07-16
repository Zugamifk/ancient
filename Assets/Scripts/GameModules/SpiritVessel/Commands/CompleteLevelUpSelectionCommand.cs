using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.Services;
using SpiritVessel.Model;

namespace SpiritVessel.Commands
{
    public class CompleteLevelUpSelectionCommand : ICommand
    {
        string _skillKey;
        public CompleteLevelUpSelectionCommand(string skillKey)
        {
            _skillKey = skillKey;
        }

        public void Execute(GameModel model)
        {
            var spiritVessel = Game.Model.GetModel<SpiritVesselModel>();

            var srv = new SkillService();
            srv.AcquireSkill(spiritVessel, _skillKey);

            spiritVessel.LevelUp = null;
        }
    }
}
