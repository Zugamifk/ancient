using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController
{
    public void Update(CharacterModel character, GameModel model)
    {
        var path = character.CityPath;
        if (path != null)
        {
            var distance = character.MoveSpeed * model.TimeModel.LastDeltaTime;
            while (distance > 0 && !character.AtPathEnd)
            {
                var end = (Vector2)path.Path[character.CurrentPathIndex];
                var dir = (end - character.WorldPosition);
                var distanceToEnd = dir.magnitude;
                if (distance < distanceToEnd)
                {
                    character.WorldPosition += dir.normalized * distance;
                    break;
                } else
                {
                    character.WorldPosition = end;
                    character.CurrentPathIndex++;
                    distance -= distanceToEnd;
                }
            }

            if(character.AtPathEnd)
            {
                character.OnReachedPathEnd();
                character.CityPath = null;
                character.CurrentPathIndex = 0;
            }
        }
    }
}
