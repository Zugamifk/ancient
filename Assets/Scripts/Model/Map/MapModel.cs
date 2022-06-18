using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapModel : IMapModel, IIdentifiable
{
    public Guid Id { get; } = new();
    public GridModel Grid = new GridModel();
    public IdentifiableCollection<CharacterModel> Characters = new IdentifiableCollection<CharacterModel>();

    #region IMapModel
    IGridModel IMapModel.Grid => Grid;
    #endregion
}
