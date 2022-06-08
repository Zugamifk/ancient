using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItemModel : ItemModel, IMapItemModel, IOpenable
{
    public bool IsOpen { get; set; }
}
