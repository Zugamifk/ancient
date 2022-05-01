using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseStartWaveCommand : ICommand
{
    public void Execute(GameController controller)
    {
        controller.TurretDefenseController.StartWave(controller.Model.TurretDefenseModel, controller.Model);
    }
}
