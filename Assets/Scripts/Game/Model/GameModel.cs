using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : IGameModel
{
    public MapModel MapModel = new MapModel();

    IMapModel IGameModel.Map => MapModel;
}
