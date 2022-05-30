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
            var data = DataService.GetData<TowerDefenseData>().GetTower(_name);
            var towertModel = new Models.Tower();
            towertModel.Key = data.Name;
            towertModel.AttackRadius = data.Radius;
            towertModel.Position = _position;
            towertModel.ShotsPerSecond = data.ShotsPerSecond;
            model.TowerDefense.Towers.AddItem(towertModel);
            model.TowerDefense.BuildingBeingPlaced = null;

            model.TowerDefense.Coins -= data.BuildCost;
        }
    }
}
