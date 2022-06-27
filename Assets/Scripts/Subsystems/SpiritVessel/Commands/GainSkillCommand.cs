using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.Services;
using SpiritVessel.Model;

namespace SpiritVessel.Commands
{
    public class GainSkillCommand : ICommand
    {
        string _skill;

        public GainSkillCommand(string skill) => _skill = skill;

        public void Execute(GameModel model)
        {
            var srv = new LightningStrikeService();
            srv.AcquireSkill(model.GetModel<SpiritVesselModel>().Lightning, _skill);
        }
    }
}
