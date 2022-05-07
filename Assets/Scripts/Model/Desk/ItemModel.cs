using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemModel : IItemModel
{
    public string Id { get; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string DeskSpawnLocation { get; set; }
    public event Action<int> ClickedItem;
    public void ClickItem(int button)
    {
        ClickedItem?.Invoke(button);
    }
}
