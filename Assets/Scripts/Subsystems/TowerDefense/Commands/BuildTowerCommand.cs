using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Data;
using TowerDefense.Models;

namespace TowerDefense.Commands
{
    public class BuildTowerCommand : ICommand
    {
        string _name;
        Vector2Int _position;

        public BuildTowerCommand(string name, Vector2Int position)
        {
            _name = name;
            _position = position;
        }

        public void Execute(GameModel model)
        {
            var data = DataService.GetData<TowerDefenseData>().GetTurret(_name);
            var turretModel = new Models.Tower();
            turretModel.Key = data.Name;
            turretModel.AttackRadius = data.Radius;
            turretModel.Position = _position;
            model.TowerDefense.Turrets.AddItem(turretModel);
            model.TowerDefense.BuildingBeingPlaced = null;
        }
    }
}
