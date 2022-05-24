using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TowerDefense
{
    public class TowerDefense : MonoBehaviour
    {
        [SerializeField]
        Vector2Int[] _pathPoints;

        void Start()
        {
            Game.Do(new LoadMapDataCommand());

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
            SpawnWaveUnits();
            UpdateTowerTargets();
        }

        void SpawnWaveUnits()
        {
            var tdModel = Game.Model.TurretDefense;

            if (tdModel.CurrentWave < 0) return;

            Game.Do(new UpdateTimeCommand());
            var gamedata = DataService.GetData<TurretDefenseData>();
            var waveData = gamedata.Waves[tdModel.CurrentWave];
            if (tdModel.SpawnedCount < waveData.Count)
            {
                Game.Do(new SpawnEnemyCommand(_pathPoints[0]));
            }
        }

        void UpdateTowerTargets()
        {
            foreach (var tower in Game.Model.TurretDefense.Turrets.AllItems)
            {
                Game.Do(new UpdateEnemiesInRangeOfTowerCommand(tower.Id));
            }
        }

        void UpdateProjectiles()
        {
            foreach (var tower in Game.Model.TurretDefense.Turrets.AllItems)
            {
                Game.Do(new UpdateEnemiesInRangeOfTowerCommand(tower.Id));
            }
        }
    }
}