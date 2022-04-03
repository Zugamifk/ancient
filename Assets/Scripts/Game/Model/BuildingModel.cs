using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingModel : ICityGraphNode, IBuildingModel
{
    public string Name { get; set; }
    public Vector2Int Position { get; set; }
}
