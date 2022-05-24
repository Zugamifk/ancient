using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Commands
{
    public class EnemyReachEndCommand : ICommand
    {
        Guid _id;
        public EnemyReachEndCommand(Guid id)
        {
            _id = id;
        }
        public void Execute(GameModel model)
        {
            Game.Do(new LoseLifeCommand());
            Game.Do(new RemoveEnemyCommand(_id));
        }
    }
}
