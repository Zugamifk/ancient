using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseUpdateEnemiesInRangeOfTurretCommand : ICommand
{
    Guid _id;
    public TurretDefenseUpdateEnemiesInRangeOfTurretCommand(Guid id)
    {
        _id = id;
    }

    public void Execute(GameModel model)
    {
        var turret = model.TurretDefenseModel.Turrets.GetItem(_id);
        turret.EnemiesInRange.Clear();
        foreach (var e in model.TurretDefenseModel.Enemies)
        {
            if (Vector2.Distance(e.Position, turret.Position) < turret.AttackRadius)
            {
                turret.EnemiesInRange.Add(e.Id);
            }
        }
    }
}
