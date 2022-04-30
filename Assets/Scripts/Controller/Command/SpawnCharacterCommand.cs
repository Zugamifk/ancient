using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharacterCommand : ICommand
{
    string _name;
    string _position;
    public SpawnCharacterCommand(string name, string position)
    {
        _name = name;
        _position = position;
    }

    public void Execute(GameController controller)
    {
        var spawnPosition = controller.ParsePosition(_position);
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
