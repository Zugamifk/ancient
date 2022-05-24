using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class StartGameCommand : ICommand
    {
        Vector2Int _spawnPosition;
        Vector2Int _destination;
        public StartGameCommand(Vector2Int spawnPosition, Vector2Int destination)
        {
            _spawnPosition = spawnPosition;
            _destination = destination;
        }

        public void Execute(GameModel model)
        {
            var towerDefenseData = DataService.GetData<TurretDefenseData>();
            var towerDefenseModel = new TurretDefenseModel();
            towerDefenseModel.Lives = towerDefenseData.StartingLives;
            towerDefenseModel.MaxLives = towerDefenseData.StartingLives;
            towerDefenseModel.CurrentWave = -1;
            towerDefenseModel.EndPoint = _destination;
            model.TurretDefenseModel = towerDefenseModel;
        }
    }
}