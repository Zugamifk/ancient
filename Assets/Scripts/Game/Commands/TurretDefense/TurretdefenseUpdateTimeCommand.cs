using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseUpdateTimeCommand : ICommand
{
    public void Execute(GameModel model)
    {
        var tdModel = model.TurretDefenseModel;
        tdModel.CurrentTime = model.TimeModel.RealTime - tdModel.StartTime;
    }
}
