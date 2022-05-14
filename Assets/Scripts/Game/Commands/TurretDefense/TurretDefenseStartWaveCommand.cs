using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseStartWaveCommand : ICommand
{
    public void Execute(GameModel model)
    {
        var turretModel = model.TurretDefenseModel;
        turretModel.StartTime = model.TimeModel.RealTime;
        turretModel.SpawnedCount = 0;
        turretModel.CurrentWave++;
    }
}
