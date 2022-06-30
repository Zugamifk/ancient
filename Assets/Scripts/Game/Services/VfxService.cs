using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VfxService
{
    public static void Play(string effectKey, Vector3 position, Transform parent)
    {
        var splatter = DataService.GetData<VfxCollection>().GetItem(effectKey);
        var inst = GameObject.Instantiate(splatter);
        inst.transform.parent = parent;
        inst.transform.position = position;
        inst.SetLayerRecursively(parent.gameObject.layer);
    }
}
