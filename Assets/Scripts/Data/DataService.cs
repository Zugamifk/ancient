using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DataService
{
    static Dictionary<System.Type, ScriptableObject> _dataTypeToCollection = new Dictionary<System.Type, ScriptableObject>();

    internal static void Register<T>(T collection) where T : ScriptableObject
    {
        _dataTypeToCollection[typeof(T)] = collection;
    }

    public static T GetData<T>() where T : ScriptableObject
    {
        return (T)_dataTypeToCollection[typeof(T)];
    }
}