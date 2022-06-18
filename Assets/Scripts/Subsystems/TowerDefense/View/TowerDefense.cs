using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TowerDefense.Data;
using City.Commands;
using TowerDefense.Commands;
using TowerDefense.ViewModel;
using City.Model;

namespace TowerDefense.View
{
    public class TowerDefense : MonoBehaviour
    {
        [SerializeField]
        Vector2Int[] _pathPoints;

        CityModel _cityModel;

        void Start()
        {
            Game.Do(new LoadMapDataCommand(_cityModel.MapModel));

            var pathfinder = new PathFinder();
            var pairs = _pathPoints.Zip(_pathPoints.Skip(1), (a, b) => (a, b));
            foreach (var pair in pairs)
            {
                Game.Do(new BuildRoadCommand(pair.a, pair.b));
            }

            Game.Do(new StartGameCommand(_pathPoints[0], _pathPoints[1]));
            Game.Do(new StartWaveCommand());
        }

        public void Update()
        {
            Game.Do(new UpdateEnemyListCommand());
            SpawnWaveUnits();
            UpdateTowers();
        }

        void SpawnWaveUnits()
        {
            var tdModel = Game.Model.GetModel<ITowerDefense>();

            if (tdModel.CurrentWave < 0) return;

            Game.Do(new UpdateTimeCommand());
            var gamedata = DataService.GetData<TowerDefenseData>();
            var waveData = gamedata.Waves[tdModel.CurrentWave];
            if (tdModel.SpawnedCount < waveData.Count)
            {
                Game.Do(new SpawnEnemyCommand(_pathPoints[0]));
            }
        }

        void UpdateTowers()
        {
            foreach (var tower in Game.Model.GetModel<ITowerDefense>().Towers.AllItems)
            {
                Game.Do(new UpdateEnemiesInRangeOfTowerCommand(tower.Id));
                Game.Do(new UpdateTowerFiringCommand(tower.Id));
            }
            Game.Do(new UpdateProjectilesCommand());
        }
    }
}