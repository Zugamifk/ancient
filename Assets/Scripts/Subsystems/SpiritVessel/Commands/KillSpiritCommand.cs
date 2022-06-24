using SpiritVessel.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.Commands
{
    public class KillSpiritCommand : ICommand
    {
        Guid _id;

        public KillSpiritCommand(Guid id)
        {
            _id = id;
        }

        public void Execute(GameModel model)
        {
            Game.Do(new RemoveCharacterCommand(_id));
            model.GetModel<SpiritVesselModel>().MapModel.CharacterIds.Remove(_id);
            Game.Do(new GainExperienceCommand(5));
        }
    }
}