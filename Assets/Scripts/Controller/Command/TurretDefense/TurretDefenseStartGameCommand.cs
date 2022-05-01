using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseStartGameCommand : ICommand
{
    public void Execute(GameController controller)
    {
        controller.TurretDefenseController.StartGame(controller.Model.TurretDefenseModel, controller.Model, new Vector2Int(10, 0), new Vector2Int(1,1));
    }
}
