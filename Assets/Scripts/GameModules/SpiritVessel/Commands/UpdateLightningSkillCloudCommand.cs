using SpiritVessel.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SpiritVessel.Commands
{
    public class UpdateLightningSkillCloudCommand : ICommand
    {
        Guid _id;
        ISet<Guid> _coveredSpirits;

        public UpdateLightningSkillCloudCommand(Guid id, ISet<Guid> coveredSpirits)
        {
            _id = id;
            _coveredSpirits = coveredSpirits;
        }

        public void Execute(GameModel model)
        {
            var vessel = Game.Model.GetModel<SpiritVesselModel>();
            var lightning = vessel.LightningSkill;
            var cloud = lightning.Clouds.GetItem(_id);
            var change = Time.deltaTime / lightning.CoolDown;
            cloud.BoltTimer -= change;

            var step = Time.deltaTime * lightning.Speed * lightning.MoveDirection;
            cloud.Position += step;

            if(cloud.Position.magnitude > vessel.OutsideRadius)
            {
                var d = cloud.Position.normalized;
                cloud.Position = -cloud.Position + d;
            }

            if (cloud.BoltTimer <= 0)
            {
                cloud.BoltTimer += lightning.CoolDown;
                if (_coveredSpirits.Count > 0)
                {
                    DoLightningStrike(model, cloud);
                }
            }
        }

        void DoLightningStrike(GameModel model, LightningSkillCloudModel cloud)
        {
            var index = UnityEngine.Random.Range(0, _coveredSpirits.Count);
            var item = _coveredSpirits.ElementAt(index);
            var target = model.Characters.GetItem(item);
            Game.Do(new DoLightningStrikeCommand(target.Position));
        }
    }
}
