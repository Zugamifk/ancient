using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCollection : ScriptableObject
{
    public GameObject[] Buildings;

    public Dictionary<string, GameObject> NameToBuilding = new Dictionary<string, GameObject>();

    private void OnEnable()
    {
        foreach (var b in Buildings)
        {
            if (b != null)
            {
                NameToBuilding.Add(b.name, b);
            } else
            {
                throw new System.InvalidOperationException("Null in BuildingCollection!");
            }
        }
    }
}
