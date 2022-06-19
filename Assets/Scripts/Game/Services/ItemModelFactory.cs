//#define DEBUG_LOG
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class ItemModelFactory
{
    public delegate ItemModel ModelFactoryDelegate(ItemData data);

    static Dictionary<Type, ModelFactoryDelegate> _itemDataTypetoModelFactory = new();
    static Dictionary<Type, ModelFactoryDelegate> _itemModelTypetoModelFactory = new();

    static ItemModelFactory()
    {
        RegisterFactory<PackageItemData>(data =>
        {
            var packageData = data as PackageItemData;
            return new PackageItemModel()
            {
                Contents = packageData.Contents.Select(i => i.Name).ToList()
            };
        });
    }

    public static void RegisterFactory<TData>(ModelFactoryDelegate factory)
        where TData : ItemData
    {
        if (_itemDataTypetoModelFactory.ContainsKey(typeof(TData)))
        {
            throw new InvalidOperationException($"A factory for data type {typeof(TData)} is already registered!");
        }

#if DEBUG_LOG
        Debug.Log($"Registered factory for {typeof(TData)}");
#endif

        _itemDataTypetoModelFactory[typeof(TData)] = factory;
    }

    public static ItemModel GetModel(ItemData data)
    {
        var type = data.GetType();
        if (!_itemDataTypetoModelFactory.TryGetValue(type, out ModelFactoryDelegate factory))
        {
#if DEBUG_LOG
            Debug.Log($"No model of type {type}, creating default.");
#endif
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
