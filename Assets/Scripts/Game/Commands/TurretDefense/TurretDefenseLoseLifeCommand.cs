using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseLoseLifeCommand : ICommand
{
    public void Execute(GameModel model)
    {
        var tdModel = model.TurretDefenseModel;
        tdModel.Lives--;
        if(tdModel.Lives <=0)
        {
            Game.Do(new TurretDefenseLoseGameCommand());
        }
    }
}
