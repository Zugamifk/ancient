using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.Model
{
    public class MapItemModel : ItemModel, IMapItemModel, IOpenable
    {
        public bool IsOpen { get; set; }
    }
}