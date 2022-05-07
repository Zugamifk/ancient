using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseLoseLifeCommand : ICommand
{
    public void Execute(GameController controller)
    {
        var tdModel = controller.Model.TurretDefenseModel;
        tdModel.Lives--;
        if(tdModel.Lives <=0)
        {
            controller.DoCommand(new TurretDefenseLoseGameCommand());
        }
    }
}
