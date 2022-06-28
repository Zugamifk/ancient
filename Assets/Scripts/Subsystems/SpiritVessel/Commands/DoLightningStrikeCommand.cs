using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.Model;
using System;

namespace SpiritVessel.Commands
{
    public class DoLightningStrikeCommand : ICommand
    {
        Guid _id;

        public DoLightningStrikeCommand(Guid id) => _id = id;

        public void Execute(GameModel model)
        {
            var lightning = Game.Model.GetModel<SpiritVesselModel>().LightningSkill;
            var cloud = lightning.Clouds.GetItem(_id);
            var strike = new AttackModel()
            {
                Key = "LightningStrike",
                Position = cloud.Position + UnityEngine.Random.insideUnitCircle * cloud.Radius
            };
            Game.Model.GetModel<SpiritVesselModel>().Attacks.AddItem(strike);
        }
    }
}
