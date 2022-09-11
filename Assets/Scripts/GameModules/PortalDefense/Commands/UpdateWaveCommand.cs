using Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PortalDefense.Model;
using System.Linq;

namespace PortalDefense.Commands
{
    public class UpdateWaveCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            var dt = model.TimeModel.LastDeltaTime;
            var pdm = model.GetModel<PortalDefenseModel>();
            var wave = pdm.CurrentWave;
            var spawns = pdm.Spawns.AllItems;
            foreach(var s in spawns)
            {
                s.SpawnQueue.Clear();
            }

            for (wave.WaveCounter += dt * (wave.SpawnsPerMinute / 60); wave.WaveCounter > 1 && wave.EnemiesRemaining > 0; wave.WaveCounter--, wave.EnemiesRemaining--)
            {
                var spawn = spawns.ElementAt(Random.Range(0, spawns.Count()));
                var enemy = new EnemyModel();
                enemy.Movement.CurrentNode = spawn.PathNode.Next;
                enemy.Movement.CurrentPosition = spawn.PathNode.WorldPosition;
                pdm.SpawnedEnemies.AddItem(enemy);
                spawn.SpawnQueue.Add(enemy.Id);
            }
        }
    }
}
