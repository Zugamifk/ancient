using Map.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.Model
{
    public class MapModel : IMapModel
    {
        public GridModel Grid = new GridModel();
        public IdentifiableCollection<CharacterModel> Characters = new IdentifiableCollection<CharacterModel>();

        #region IMapModel
        IGridModel IMapModel.Grid => Grid;
        #endregion
    }
}