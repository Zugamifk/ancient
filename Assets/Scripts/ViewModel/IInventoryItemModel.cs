using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemModel : IIdentifiable
{
    public string Name { get; }
    public string DeskSpawnLocation { get; }
    public event Action<int> ClickedItem;
    public void ClickItem(int button);
}
