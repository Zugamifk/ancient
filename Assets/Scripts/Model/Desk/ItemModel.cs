using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemModel : IItemModel
{
    public string Name { get; set; }
    public string DeskSpawnLocation { get; set; }
    public event EventHandler<int> ClickedItem;
    public void ClickItem(int button)
    {
        ClickedItem?.Invoke(this, button);
    }
}
