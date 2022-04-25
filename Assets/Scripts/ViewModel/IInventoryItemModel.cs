using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemModel
{
    public string Name { get; }
    public string DeskSpawnLocation { get; }
    public event EventHandler<int> ClickedItem;
    public void ClickItem(int button);
}
