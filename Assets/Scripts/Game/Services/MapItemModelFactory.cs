using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map.Model;
using Map.Data;

namespace Map.Services
{
    static class MapItemModelFactory
    {
        [RuntimeInitializeOnLoadMethod]
        static void RegisterMapModelFactory()
        {
            ItemModelFactory.RegisterFactory<MapItemData>(MakeMapItemModel);
        }

        static ItemModel MakeMapItemModel(ItemData item)
        {
            var model = new MapItemModel();
            model.IsOpen = false;
            return model;
        }
    }
}
