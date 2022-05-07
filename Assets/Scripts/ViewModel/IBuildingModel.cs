using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildingModel : IIdentifiable
{
    string Name { get; }
    Vector2Int Position { get; }
    Vector2Int EntrancePosition { get; }
    event Action<int> Clicked;
    void OnClicked(int button);
}
