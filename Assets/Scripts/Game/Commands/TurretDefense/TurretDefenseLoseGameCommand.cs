using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseLoseGameCommand : ICommand
{
    public void Execute(GameModel model)
    {
        model.TurretDefenseModel.CurrentWave = -1;
        Debug.Log("Game over!!");
    }
}
