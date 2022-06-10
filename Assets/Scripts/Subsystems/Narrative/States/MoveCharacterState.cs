using City.Services;
using Map.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative.States
{
    public class MoveCharacterState : NarrativeState<MoveCharacterData>
    {
        static LocationFinder _locationFinder = new LocationFinder();

        bool _reachedEnd = false;

        public override void EnterState(IGameModel model)
        {
            var position = _locationFinder.FindMapLocation(Data.Destination, model.City);
            Game.Do(new MoveCharacterCommand()
            {
                CharacterName = Data.Character,
                Destination = Vector2Int.FloorToInt(position),
                ReachedPathEnd = ReachedPathEnd
            });
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

        void ReachedPathEnd(MovementModel _)
        {
            _reachedEnd = true;
        }
    }
}