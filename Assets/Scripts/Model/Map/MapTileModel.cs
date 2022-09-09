using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;

namespace Model
{
    public class MapTileModel : ITileModel
    {
        public string Type;
        public int MoveCost;

        #region IMapTileModel
        string ITileModel.Type => Type;
        int ITileModel.MoveCost => MoveCost;
        #endregion
    }
}