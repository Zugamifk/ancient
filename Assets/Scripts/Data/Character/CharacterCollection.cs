    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollection : ScriptableObject
{
    [SerializeField]
    CharacterData[] _agents;

    Dictionary<string, CharacterData> _nameToAgentData = new Dictionary<string, CharacterData>();

    public CharacterData GetData(string name)
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
