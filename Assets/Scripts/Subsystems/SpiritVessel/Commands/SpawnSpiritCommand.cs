using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;

namespace SpiritVessel.Commands
{
    public class SpawnSpiritCommand : SpawnCharacterCommand
    {
        public SpawnSpiritCommand(string name, Vector2 position)
            : base(name, position, Game.Model.GetModel<ISpiritVesselModel>().Map.Id)
        {
        }

        protected override void OnSpawnedCharacter(GameModel model, CharacterModel character)
        {
            
        }
    }
}
