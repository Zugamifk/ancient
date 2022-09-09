using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.Data;
using TowerDefense.Models;
using Model;

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
            var data = DataService.GetData<TowerDefenseData>().GetTower(_name);
            var towerModel = new Tower();
            towerModel.Key = data.Name;
            towerModel.AttackRadius = data.Radius;
            towerModel.Position = _position;
            towerModel.ShotsPerSecond = data.ShotsPerSecond;
            var towerDefenseModel = model.GetModel<TowerDefenseGameModel>();
            towerDefenseModel.Towers.AddItem(towerModel);
            towerDefenseModel.BuildingBeingPlaced = null;

            towerDefenseModel.Coins -= data.BuildCost;
        }
    }
}
