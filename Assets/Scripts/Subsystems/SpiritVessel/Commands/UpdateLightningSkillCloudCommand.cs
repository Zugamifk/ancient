using SpiritVessel.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.Commands
{
    public class UpdateLightningSkillCloudCommand : ICommand
    {
        Guid _id;

        public UpdateLightningSkillCloudCommand(Guid id) => _id = id;

        public void Execute(GameModel model)
        {
            var lightning = Game.Model.GetModel<SpiritVesselModel>().LightningSkill;
            var cloud = lightning.Clouds.GetItem(_id);
            var change = Time.deltaTime / lightning.CoolDown;
            cloud.BoltTimer -= change;

            var step = Time.deltaTime * lightning.Speed * lightning.MoveDirection;
            cloud.Position += step;

            if(cloud.BoltTimer <= 0)
            {
                cloud.BoltTimer += lightning.CoolDown;
                DoLightningStrike(cloud);
            }
        }

        void DoLightningStrike(LightningSkillCloudModel cloud)
        {
            Game.Do(new DoLightningStrikeCommand(_id));
        }
    }
}
