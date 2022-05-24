using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
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
            var data = DataService.GetData<TurretDefenseData>().GetTurret(_name);
            var turretModel = new TurretModel();
            turretModel.Key = data.Name;
            turretModel.AttackRadius = data.Radius;
            turretModel.Position = _position;
            model.TurretDefenseModel.Turrets.AddItem(turretModel);
            model.TurretDefenseModel.BuildingBeingPlaced = null;
        }
    }
}
