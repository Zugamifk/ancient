using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemModel : IItemModel
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Key { get; set; }
    public string DeskSpawnLocation { get; set; }
    public event Action<int> ClickedItem;
    public void ClickItem(int button)
    {
        ClickedItem?.Invoke(button);
    }
}
