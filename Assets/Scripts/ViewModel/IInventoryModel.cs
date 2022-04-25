using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryModel 
{
    public IEnumerable<IItemModel> Items { get; }
    public IItemModel GetItem(string name);
}
