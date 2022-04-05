    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentCollection : ScriptableObject, IPrefabCollection
{
    public AgentData[] Agents;

    Dictionary<string, AgentData> _nameToAgentData = new Dictionary<string, AgentData>();

    private void OnEnable()
    {
        foreach(var a in Agents)
        {
            _nameToAgentData[a.Name] = a;
        }
    }

    GameObject IPrefabCollection.GetPrefab(string name)
    {
        return _nameToAgentData[name].MapPrefab;
    }
}
