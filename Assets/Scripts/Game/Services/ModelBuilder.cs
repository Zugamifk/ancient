using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ModelBuilder
{
    public delegate ItemModel ModelFactoryDelegate(ItemData data);

    static Dictionary<Type, ModelFactoryDelegate> _itemDataTypetoModelFactory = new();

    static ModelBuilder()
    {
        RegisterFactory<PackageItemData>(data => {
            var packageData = data as PackageItemData;
            return new PackageItemModel()
            {
                Contents = packageData.Contents.Select(i => i.Name).ToList()
            };
        });

        //case PackageItemData packageData:
        //        itemModel = new PackageItemModel()
        //        {
        //            Contents = packageData.Contents.Select(i => i.Name).ToList()
        //        };
        //break;
        //    case MapItemData mapItemData:
        //        itemModel = new MapItemModel();
        //break;
        //default:
        //        itemModel = new ItemModel();
        //break;
    }

    public static void RegisterFactory<TData>(ModelFactoryDelegate factory)
    {
        if (_itemDataTypetoModelFactory.ContainsKey(typeof(TData)))
        {
            throw new InvalidOperationException($"A factory for data type {typeof(TData)} is already registered!");
        }

        _itemDataTypetoModelFactory[typeof(TData)] = factory;
    }

    public static ItemModel GetModel(ItemData data)
    {
        var type = data.GetType();
        if (!_itemDataTypetoModelFactory.TryGetValue(type, out ModelFactoryDelegate factory))
        {
            factory = DefaultFactory;
        }

        var model = factory?.Invoke(data);
        model.Key = data.Name;
        model.DeskSpawnLocation = data.DeskSpawnLocation;
        return model;
    }

    static ItemModel DefaultFactory(ItemData data)
    {
        return new ItemModel();
    }
}
