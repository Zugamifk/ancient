using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryModel 
{
    public IIdentifiableLookup<IItemModel> Items { get; }
    public IItemModel GetItem(string name);
}
