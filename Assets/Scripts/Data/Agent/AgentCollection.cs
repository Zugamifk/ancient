    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentCollection : ScriptableObject
{
    [SerializeField]
    AgentData[] _agents;

    Dictionary<string, AgentData> _nameToAgentData = new Dictionary<string, AgentData>();

    public AgentData GetAgent(string name)
    {
        return _nameToAgentData[name];
    }

    private void OnEnable()
    {
        foreach(var a in _agents)
        {
            _nameToAgentData[a.Name] = a;
        }
    }

}
