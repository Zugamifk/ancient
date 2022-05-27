using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Commands
{
    public class RemoveEnemyCommand : ICommand
    {
        Guid _id;
        public RemoveEnemyCommand(Guid id) => _id = id;
        public void Execute(GameModel model)
        {
            model.TowerDefense.EnemyIds.Remove(_id);
            Game.Do(new RemoveCharacterCommand()
            {
                CharacterId = _id
            });
        }
    }
}
