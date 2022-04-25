using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryModel 
{
    public IEnumerable<IInventoryItemModel> Items { get; }
}
