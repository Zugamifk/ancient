using Map.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.Model
{
    public class MapModel : IMapModel
    {
        public GridModel Grid = new GridModel();

        #region IMapModel
        IGridModel IMapModel.Grid => Grid;
        #endregion
    }
}