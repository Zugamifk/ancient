using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatController : ICheatController
{
    GameController _gameController;

    public IGameModel GameModel { get; }

    public CheatController(GameController controller, IGameModel model)
    {
        _gameController = controller;
        GameModel = model;
    }

    public void SetTile(int x, int y, string type)
    {
        _gameController.SetTile(x, y, type);
    }
}
