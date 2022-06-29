using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;
using SpiritVessel.Model;

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
            var hp = new HitpointsHealthModel();
            hp.Id = character.Id;
            hp.Max = 5;
            hp.Current = 5;
            model.GetModel<SpiritVesselModel>().HitpointModels.AddItem(hp);
        }
    }
}
