using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskItemSpawn : MonoBehaviour
{
    [SerializeField]
    string _spawnName;

    public string SpawnName => _spawnName;

    public void PositionItem(DeskItem item)
    {
        var tf = item.transform;
        tf.SetParent(transform);
        SetLayer(tf, gameObject.layer);
        tf.localPosition = Vector3.zero;
    }

    void SetLayer(Transform tf, int layer)
    {
        tf.gameObject.layer = layer;
        foreach (Transform child in tf)
        {
            SetLayer(child, layer);
        }
    }
}
