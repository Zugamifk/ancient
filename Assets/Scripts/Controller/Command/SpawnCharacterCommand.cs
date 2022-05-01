using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterCommand : ICommand
{
    public string Name;
    public string PositionName;
    public Vector2Int Position;
    public Action<CharacterModel> OnSpawned;
    public bool IsUnique;
    public void Execute(GameController controller)
    {
        var spawnPosition = string.IsNullOrEmpty(PositionName) ? Position : controller.ParsePosition(PositionName);
        var data = controller.CharacterCollection.GetData(Name);
        var character = new CharacterModel()
        {
            Profile = new ProfileModel()
            {
                Name = Name,
            },
            Movement = new MovementModel()
            {
                MoveSpeed = data.MoveSpeed,
                WorldPosition = spawnPosition
            }
        };
        
        controller.Model.Characters.Add(character.Id, character);

        Debug.Log($"Added id {Name} {character.Id}");
        
        if (IsUnique)
        {
            controller.Model.UniqueCharacterNameToId.Add(Name, character.Id);
        }

        OnSpawned?.Invoke(character);
    }
}
