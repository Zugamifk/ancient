using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildingModel
{
    string Name { get; }
    Vector2Int Position { get; }
    Vector2Int EntrancePosition { get; }
    event EventHandler<int> Clicked;
    void OnClicked(int button);
}
