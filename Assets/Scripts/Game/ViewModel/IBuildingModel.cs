using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildingModel
{
    public string Name { get; }
    public Vector2Int Position { get; }
}
