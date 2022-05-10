using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseStartWaveCommand : ICommand
{
    public void Execute(GameController controller)
    {
        var model = controller.Model.TurretDefenseModel;
        model.StartTime = controller.Model.TimeModel.RealTime;
        model.SpawnedCount = 0;
        model.CurrentWave++;
    }
}
