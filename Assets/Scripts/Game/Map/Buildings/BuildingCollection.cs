using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingCollection : ScriptableObject
{
    public Building[] Buildings;

    public Dictionary<string, Building> NameToBuilding = new Dictionary<string, Building>();

    private void OnEnable()
    {
        foreach(var b in Buildings)
        {
            var name = b.GetComponent<IBuildingBehaviour>().Name;
            NameToBuilding.Add(name, b);
        }
    }
}
