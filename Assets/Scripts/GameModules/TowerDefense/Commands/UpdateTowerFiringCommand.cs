using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Behaviours;
using TowerDefense.Models;
using Model;

namespace TowerDefense.Commands
{
    public class UpdateTowerFiringCommand : ICommand
    {
        static TowerBehaviour _towerBehaviour = new();
        Guid _id;
        public UpdateTowerFiringCommand(Guid id) => _id = id;

        public void Execute(GameModel model)
        {
            var towerDefenseModel = model.GetModel<TowerDefenseGameModel>();
            _towerBehaviour.FireProjectiles(model, towerDefenseModel.Towers.GetItem(_id));
        }
    }
}
