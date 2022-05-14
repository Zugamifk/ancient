using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseStartPlacingTurretCommand : ICommand
{
    string _turretName;
    public TurretDefenseStartPlacingTurretCommand(string turretName)
    {
        _turretName = turretName;
    }

    public void Execute(GameModel model)
    {
        model.TurretDefenseModel.BuildingBeingPlaced = _turretName;
    }
}
