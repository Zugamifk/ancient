using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskItemModel : IDeskItemModel
{
    public string Name { get; set; }
    public event EventHandler<int> ClickedItem;
    public void ClickItem(int button)
    {
        ClickedItem?.Invoke(this, button);
    }
}
