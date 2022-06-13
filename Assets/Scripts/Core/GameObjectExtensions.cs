using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameObjectExtensions
{
    public static void SetLayerRecursively(this GameObject go, int layermask)
    {
        go.layer = layermask;
        foreach (Transform child in go.transform)
        {
            child.gameObject.SetLayerRecursively(layermask);
        }
    }
}
