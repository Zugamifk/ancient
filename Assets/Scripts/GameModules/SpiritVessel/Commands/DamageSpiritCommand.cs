using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.Model;
using Model;

namespace SpiritVessel.Commands
{
    public class DamageSpiritCommand : ICommand
    {
        Guid _targetId;
        int _damage;

        public DamageSpiritCommand(Guid targetId, int damage)
        {
            _targetId = targetId;
            _damage = damage;
        }

        public void Execute(GameModel model)
        {
            var hp = Game.Model.GetModel<SpiritVesselModel>().HitpointModels.GetItem(_targetId);
            hp.Current -= _damage;
            if(hp.Current <= 0)
            {
                Game.Do(new KillSpiritCommand(_targetId));
            }
        }
    }
}
