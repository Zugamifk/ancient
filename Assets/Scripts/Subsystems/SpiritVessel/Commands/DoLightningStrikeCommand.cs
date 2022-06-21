using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.Model;

namespace SpiritVessel.Commands
{
    public class DoLightningStrikeCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            var strike = new AttackModel()
            {
                Key = "LightningStrike",
                Position = 5 * Random.insideUnitCircle
            };
            Game.Model.GetModel<SpiritVesselModel>().Attacks.AddItem(strike);
        }
    }
}
