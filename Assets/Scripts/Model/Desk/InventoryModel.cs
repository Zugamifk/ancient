using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel : IInventoryModel
{
    public Dictionary<string, ItemModel> Items = new Dictionary<string, ItemModel>();


    #region IInventoryModel
    IEnumerable<IInventoryItemModel> IInventoryModel.Items => Items.Values;
    #endregion
}
