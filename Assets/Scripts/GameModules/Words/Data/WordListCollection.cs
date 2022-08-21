using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Words.Data
{
    public class WordListCollection : ScriptableObject
    {
        [SerializeField] List<WordList> _allLists = new();
    }
}
