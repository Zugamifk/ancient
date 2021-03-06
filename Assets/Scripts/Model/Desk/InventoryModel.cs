using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel : IInventoryModel
{
    public IdentifiableCollection<ItemModel> Items = new IdentifiableCollection<ItemModel>();

    public IItemModel GetItem(string name) => Items[name];
    #region IInventoryModel
    IIdentifiableLookup<IItemModel> IInventoryModel.Items => Items;
    #endregion
}
