using Map.Model;
using Map.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.Commands
{
    public class MoveCharacterCommand : ICommand
    {
        public Guid CharacterId;
        public string CharacterName;
        public Vector2Int Destination;
        public Action<MovementModel> ReachedPathEnd;
        public MapModel Map;
        public void Execute(GameModel model)
        {
            var character = string.IsNullOrEmpty(CharacterName) ?
                model.Characters.GetItem(CharacterId) :
                model.Characters.GetItem(CharacterName);
            var startPoint = character.Movement.WorldPosition;
            var path = new PathFinder()
                .GetPath(Vector2Int.FloorToInt(startPoint), Destination, Map.Grid);
            character.Movement.CityPath = path;
            if (ReachedPathEnd != null)
            {
                character.Movement.ReachedPathEnd += ReachedPathEnd;
            }
        }
    }
}