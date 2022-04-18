using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileDataEditorConfig : ScriptableObject
{
    [System.Serializable]
    public class TypeConfig
    {
        public string Name;
        public Color EdgeColor;
    }

    public TypeConfig[] TypeConfigs;
}
