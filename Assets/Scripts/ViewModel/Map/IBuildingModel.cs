using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildingModel : IIdentifiable, IKeyHolder, IMapPositionable
{
    Vector2Int EntrancePosition { get; }
}
