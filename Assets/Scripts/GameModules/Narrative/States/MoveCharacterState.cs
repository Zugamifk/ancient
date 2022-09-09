using City.Services;
using City.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;

namespace Narrative.States
{
    public class MoveCharacterState : NarrativeState<MoveCharacterData>
    {
        static LocationFinder _locationFinder = new LocationFinder();

        bool _reachedEnd = false;

        public override void EnterState(IGameModel model)
        {
            var position = _locationFinder.FindMapLocation(Data.Destination, model.GetModel<ICityModel>());
            var cmd = new MoveCharacterCommand()
            {
                CharacterName = Data.Character,
                Destination = Vector2Int.FloorToInt(position),
                ReachedPathEnd = ReachedPathEnd
            };
            Game.Do(cmd);
        }

        public override string UpdateState(IGameModel model)
        {
            if (_reachedEnd)
            {
                return Data.Next;
            }
            else
            {
                return Data.Name;
            }
        }

        void ReachedPathEnd(MapMovementModel _)
        {
            _reachedEnd = true;
        }
    }
}