using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICheatController
{
    IGameModel GameModel { get; }
    void SetTile(int x, int y, string type);
}
