using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseSpawnEnemyCommand : ICommand
{
    string _name;
    Vector2Int _position;

    public TurretDefenseSpawnEnemyCommand(string name, Vector2Int position)
    {
        _name = name;
        _position = position;
    }

    public void Execute(GameController controller)
    {
        var data = controller.CharacterCollection.GetData(_name);
        var enemy = new CharacterModel()
        {
            Profile = new ProfileModel()
            {
                Name = _name,
            },
            Movement = new MovementModel()
            {
                MoveSpeed = data.MoveSpeed,
                WorldPosition = _position
            },
            Health = new HealthModel()
            {
                MaxHealth = data.MaxHealth,
                CurrentHealth = data.MaxHealth
            }
        };
        controller.Model.TurretDefenseModel.Enemies.Add(enemy);
    }
}
