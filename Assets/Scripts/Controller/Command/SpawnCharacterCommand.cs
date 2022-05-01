using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterCommand : ICommand
{
    string _name;
    string _positionName;
    Vector2Int _position;
    public SpawnCharacterCommand(string name, string position)
    {
        _name = name;
        _positionName = position;
    }

    public SpawnCharacterCommand(string name, Vector2Int position)
    {
        _name = name;
        _position = position;
    }

    public void Execute(GameController controller)
    {
        var spawnPosition = string.IsNullOrEmpty(_positionName) ? _position : controller.ParsePosition(_positionName);
        var data = controller.CharacterCollection.GetData(_name);
        var agent = new CharacterModel()
        {
            Profile = new ProfileModel()
            {
                Name = _name,
            },
            Movement = new MovementModel()
            {
                MoveSpeed = data.MoveSpeed,
                WorldPosition = spawnPosition
            }
        };
        controller.Model.Characters.Add(_name, agent);
    }
}
