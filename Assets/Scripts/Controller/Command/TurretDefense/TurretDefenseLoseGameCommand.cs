using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseLoseGameCommand : ICommand
{
    public void Execute(GameController controller)
    {
        var model = controller.Model.TurretDefenseModel;
        model.CurrentWave = -1;
        Debug.Log("Game over!!");
    }
}
