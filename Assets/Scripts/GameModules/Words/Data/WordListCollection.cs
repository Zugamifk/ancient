using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Words.Data
{
    public class WordListCollection : ScriptableObject, IRegisteredData
    {
        [SerializeField] List<WordList> _allLists = new();

        public IReadOnlyList<WordList> AllLists => _allLists;
    }
}
