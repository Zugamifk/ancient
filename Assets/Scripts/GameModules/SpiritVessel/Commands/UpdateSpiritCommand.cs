using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

namespace SpiritVessel.Commands
{
    public class UpdateSpiritCommand : ICommand
    {
        Guid _id;

        public UpdateSpiritCommand(Guid id)
        {
            _id = id;
        }

        public void Execute(GameModel model)
        {
            var character = model.Characters.GetItem(_id);
            var dir = -character.Position.normalized;
            var step = dir * model.TimeModel.LastDeltaTime;

            if(step.magnitude > character.Position.magnitude)
            {
                Game.Do(new SpiritReachEndcommand(_id));
            } else
            {
                character.Position += step;
            }
        }
    }
}
