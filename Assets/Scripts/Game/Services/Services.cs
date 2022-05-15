using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal static class Services
{
    static Dictionary<Type, object> _serviceTypeToInstance = new Dictionary<Type, object>();
    public static T Get<T>() where T : new()
    {
        if(!_serviceTypeToInstance.TryGetValue(typeof(T), out object result))
        {
            result = new T();
            _serviceTypeToInstance[typeof(T)] = result;
        }
        return (T)result;
    }
}
