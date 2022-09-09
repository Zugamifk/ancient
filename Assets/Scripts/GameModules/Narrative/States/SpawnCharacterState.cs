using City.Services;
using City.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;

namespace Narrative.States
{
    public class SpawnCharacterState : NarrativeState<SpawnCharacterData>
    {
        static LocationFinder _locationFinder = new();
        public override string UpdateState(IGameModel model)
        {
            var position = _locationFinder.FindMapLocation(Data.Position, model.GetModel<ICityModel>());
            Game.Do(new SpawnCharacterCommand(Data.Character, position, model.GetModel<ICityModel>().Map.Id));
            return Data.Next;
        }
    }
}