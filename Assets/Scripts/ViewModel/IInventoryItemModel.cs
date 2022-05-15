using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemModel : IIdentifiable, IKeyHolder
{
    public string DeskSpawnLocation { get; }
}