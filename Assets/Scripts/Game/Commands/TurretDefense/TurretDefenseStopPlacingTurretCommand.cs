using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseStopPlacingTurretCommand : ICommand
{
    public void Execute(GameModel model)
    {
        model.TurretDefenseModel.BuildingBeingPlaced = null;
    }
}
