using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskModel : IDeskModel
{
    public Dictionary<string, DeskItemModel> Items = new Dictionary<string, DeskItemModel>();


    #region IDeskModel
    IEnumerable<IDeskItemModel> IDeskModel.Items => Items.Values;
    #endregion
}
