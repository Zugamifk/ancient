using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingModel : ICityGraphNode, IBuildingModel
{
    public string Name { get; set; }
    public Vector2Int Position { get; set; }
    public Vector2Int EntrancePosition { get; set; }

    public event EventHandler<int> Clicked;
    public HashSet<string> Agents = new HashSet<string>();

    public void OnClicked(int button)
    {
        Clicked?.Invoke(this, button);
    }
}
