using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense.Commands
{
    public class AddCoinsCommand : ICommand
    {
        int _amountToAdd;
        public AddCoinsCommand(int ammountToAdd) => _amountToAdd = ammountToAdd;

        public void Execute(GameModel model)
        {
            model.TowerDefense.Coins += _amountToAdd;
        }
    }
}
