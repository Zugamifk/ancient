using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretDefenseController
{
    ICommandService _commands;
    TurretDefenseData _gameData;

    float _spawnTimer;

    public TurretDefenseController(ICommandService commands, TurretDefenseData data)
    {
        _commands = commands;
        _gameData = data;
    }

    public void Update(GameModel model)
    {

    }

    public void StartWave()
    {
        Debug.Log("Wave started!");
    }

}
