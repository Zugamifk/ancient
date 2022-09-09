using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ViewModel;

namespace Model
{
    public class MapModel : IMapModel
    {
        public Guid Id { get; } = new();
        public string Key { get; }
        public GridModel Grid = new GridModel();
        public HashSet<Guid> CharacterIds = new HashSet<Guid>();
        public IdentifiableCollection<MapMovementModel> MovementModels = new();

        #region IMapModel
        IGridModel IMapModel.Grid => Grid;
        ISet<Guid> IMapModel.CharacterIds => CharacterIds;

        #endregion

        public MapModel(string key) => Key = key;
    }
}