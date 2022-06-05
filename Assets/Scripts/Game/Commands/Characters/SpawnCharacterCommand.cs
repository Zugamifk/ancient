using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterCommand : ICommand
{
    public string Name;
    public Vector2Int Position;
    public Action<CharacterModel> OnSpawned;
    public bool IsUnique;
    public void Execute(GameModel model)
    {
        var data = DataService.GetData<CharacterCollection>().GetData(Name);
        var character = new CharacterModel();
        character.Profile = new ProfileModel()
        {
            Name = Name,
        };
        character.Movement = new MovementModel()
        {
            OwnerId = character.Id,
            MoveSpeed = data.MoveSpeed,
            WorldPosition = Position
        };

        var uniqueName = IsUnique ? Name : null;
        model.Characters.AddItem(character, uniqueName);
        model.AllIdentifiables.AddItem(character, uniqueName);

        OnSpawned?.Invoke(character);
    }
}
