using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.Model;
using System;

namespace SpiritVessel.Commands
{
    public class DoLightningStrikeCommand : ICommand
    {
        Vector2 _position;

        public DoLightningStrikeCommand(Vector2 position)
        {
            _position = position;
        }

        public void Execute(GameModel model)
        {
            var lightning = Game.Model.GetModel<SpiritVesselModel>().LightningSkill;
            var strike = new AttackModel()
            {
                Key = "LightningStrike",
                Position = _position
            };
            Game.Model.GetModel<SpiritVesselModel>().Attacks.AddItem(strike);
        }
    }
}
