    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCollection : ScriptableObject, IPrefabLookup, IRegisteredData
{
    [SerializeField]
    CharacterData[] _agents;

    Dictionary<string, CharacterData> _nameToCharacterData = new Dictionary<string, CharacterData>();

    public CharacterData GetData(string name)
    {
        return _nameToCharacterData[name];
    }

    public GameObject GetPrefab(string id) => GetData(id).MapPrefab;

    private void OnEnable()
    {
        foreach(var a in _agents)
        {
            _nameToCharacterData[a.Name] = a;
        }
        Prefabs.Register<ICharacterModel>(this);
    }

}
