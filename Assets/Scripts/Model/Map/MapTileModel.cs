using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapTileModel : IMapTileModel
{
    public string Type;
    public int MoveCost;

    #region IMapTileModel
    string IMapTileModel.Type => Type;
    int IMapTileModel.MoveCost => MoveCost;
    #endregion
}
