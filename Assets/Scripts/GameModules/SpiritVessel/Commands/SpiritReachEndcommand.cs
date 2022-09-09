using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.Model;
using Model;

namespace SpiritVessel.Commands
{
    public class SpiritReachEndcommand : ICommand
    {
        Guid _id;

        public SpiritReachEndcommand(Guid id)
        {
            _id = id;
        }

        public void Execute(GameModel model)
        {
            Game.Do(new RemoveCharacterCommand(_id));
            model.GetModel<SpiritVesselModel>().MapModel.CharacterIds.Remove(_id);
        }
    }
}
