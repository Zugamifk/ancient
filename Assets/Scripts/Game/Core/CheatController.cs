using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatController : ICheatController
{
    Director _director;

    public IGameModel GameModel { get; }

    public CheatController(Director director, IGameModel model)
    {
        _director = director;
        GameModel = model;
    }

    public void SetTile(int x, int y, string type)
    {
        _director.SetTile(x, y, type);
    }
}
