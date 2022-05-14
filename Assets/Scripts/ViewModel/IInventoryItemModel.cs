using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemModel : IIdentifiable, IKeyHolder
{
    public string DeskSpawnLocation { get; }
    public event Action<int> ClickedItem;
    public void ClickItem(int button);
}
