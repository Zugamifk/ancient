using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapModel : IMapModel
{
    public Guid Id { get; } = new();
    public GridModel Grid = new GridModel();
    public HashSet<Guid> CharacterIds = new HashSet<Guid>();

    #region IMapModel
    IGridModel IMapModel.Grid => Grid;
    ISet<Guid> IMapModel.CharacterIds => CharacterIds;
    #endregion
}
