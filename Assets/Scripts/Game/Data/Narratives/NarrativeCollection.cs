using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeCollection : ScriptableObject
{
    public NarrativeData[] Narratives;

    public Dictionary<string, NarrativeData> _nameToData = new Dictionary<string, NarrativeData>();

    private void OnEnable()
    {
        foreach ( var n in Narratives)
        {
            _nameToData[n.Name] = n;
        }
    }

    public NarrativeData GetNarrative(string name)
    {
        return _nameToData[name];
    }
}
