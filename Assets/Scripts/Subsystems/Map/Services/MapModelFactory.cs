using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map.Model;
using Map.Data;

namespace Map.Services
{
    static class MapModelFactory
    {
        [RuntimeInitializeOnLoadMethod]
        static void RegisterMapModelFactory()
        {
            ModelFactory.RegisterFactory<MapItemData>(MakeMapItemModel);
        }

        static ItemModel MakeMapItemModel(ItemData item)
        {
            var model = new MapItemModel();
            model.IsOpen = false;
            return model;
        }
    }
}
