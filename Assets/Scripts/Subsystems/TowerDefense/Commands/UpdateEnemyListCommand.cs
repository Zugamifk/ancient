using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Commands
{
    public class UpdateEnemyListCommand : ICommand
    {
        public void Execute(GameModel model)
        {
            model.TowerDefense.EnemyIds.RemoveAll(id => !model.Characters.HasId(id));
        }
    }
}
