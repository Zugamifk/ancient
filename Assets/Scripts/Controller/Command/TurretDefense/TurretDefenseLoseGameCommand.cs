using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseLoseGameCommand : ICommand
{
    public void Execute(GameController controller)
    {
        controller.TurretDefenseController.LoseGame(controller.Model.TurretDefenseModel);
    }
}
