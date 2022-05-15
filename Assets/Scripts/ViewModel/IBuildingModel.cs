using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildingModel : IIdentifiable, IKeyHolder
{
    Vector2Int Position { get; }
    Vector2Int EntrancePosition { get; }
}
