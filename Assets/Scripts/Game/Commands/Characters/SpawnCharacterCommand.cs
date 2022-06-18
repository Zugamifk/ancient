using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterCommand : ICommand
{
    string _name;
    Vector2 _position;
    Guid _mapId;

    public SpawnCharacterCommand(string name, Vector2 position, Guid mapId)
    {
        _name = name;
        _position = position;
        _mapId = mapId;
    }

    public void Execute(GameModel model)
    {
        var data = DataService.GetData<CharacterCollection>().GetData(_name);
        var character = new CharacterModel();
        character.Profile = new ProfileModel()
        {
            Name = _name,
        };
        character.Movement = new MovementModel()
        {
            OwnerId = character.Id,
            MoveSpeed = data.MoveSpeed,
            WorldPosition = _position
        };

        model.Characters.AddItem(character);
        model.AllIdentifiables.AddItem(character);

        var map = model.Maps[_mapId];
        map.CharacterIds.Add(character.Id);
    }

    protected virtual void OnSpawnedCharacter(GameModel model, CharacterModel character)
    {

    }
}
