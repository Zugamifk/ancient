using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UpdateableGameObjectRegistry
{
    static HashSet<IModelUpdateable> _updateables = new HashSet<IModelUpdateable>();
    public static IEnumerable<IModelUpdateable> Updateables => _updateables;

    public static void RegisterUpdateable(IModelUpdateable updateable)
    {
        _updateables.Add(updateable);
    }
}
