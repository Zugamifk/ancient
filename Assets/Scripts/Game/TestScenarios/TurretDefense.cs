using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TurretDefense : MonoBehaviour
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

        Game.Do(new TurretDefenseStartGameCommand(_pathPoints[0], _pathPoints[1]));
        Game.Do(new TurretDefenseStartWaveCommand());
    }

    public void Update()
    {
        SpawnWaveUnits();
        UpdateTurretTargets();
    }

    void SpawnWaveUnits()
    {
        var tdModel = Game.Model.TurretDefense;

        if (tdModel.CurrentWave < 0) return;

        Game.Do(new TurretDefenseUpdateTimeCommand());
        var gamedata = DataService.GetData<TurretDefenseData>();
        var waveData = gamedata.Waves[tdModel.CurrentWave];
        if (tdModel.SpawnedCount < waveData.Count)
        {
            Game.Do(new TurretDefenseSpawnEnemyCommand(_pathPoints[0]));
        }
    }

    void UpdateTurretTargets()
    {
        foreach (var turret in Game.Model.TurretDefense.Turrets.AllItems)
        {
            Game.Do(new TurretDefenseUpdateEnemiesInRangeOfTurretCommand(turret.Id));
        }
    }

    void UpdateProjectiles()
    {

    }
}
