using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class RemoveEnemyCommand : ICommand
    {
        Guid _id;
        public RemoveEnemyCommand(Guid id) => _id = id;
        public void Execute(GameModel model)
        {
            var character = model.Characters.GetItem(_id);
            model.TurretDefenseModel.Enemies.Remove(character);
            Game.Do(new RemoveCharacterCommand()
            {
                CharacterId = _id
            });
        }
    }
}
