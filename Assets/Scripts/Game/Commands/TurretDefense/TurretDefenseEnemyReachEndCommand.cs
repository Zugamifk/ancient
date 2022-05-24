using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseEnemyReachEndCommand : ICommand
{
    Guid _id;
    public TurretDefenseEnemyReachEndCommand(Guid id)
    {
        _id = id;
    }
    public void Execute(GameModel model)
    {
        Game.Do(new TurretDefenseLoseLifeCommand());
        Game.Do(new TurretDefenseRemoveEnemyCommand(_id));
    }
}
