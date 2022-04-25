using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryItemModel
{
    public string Name { get; }
    public event EventHandler<int> ClickedItem;
    public void ClickItem(int button);
}