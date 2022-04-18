using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheatController : ICheatController
{
    public GameModel Model;
    public MapController MapController;

    #region ICheatController
    void ICheatController.SetTile(int x, int y, string type)
    {
        MapController.SetTile(Model.MapModel, x, y, type);
    }
    IGameModel ICheatController.GameModel => Model;
    #endregion
}
