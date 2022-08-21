using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Words.Data
{
    public class WordList : ScriptableObject
    {
        [SerializeField] string _category;
        [SerializeField] List<WordInfo> _words = new();
        [SerializeField] List<WordList> _containedLists = new();

        public string Category => _category;
        public IReadOnlyList<WordInfo> Words => _words;
        public IReadOnlyList<WordList> ContainedLists => _containedLists;

        public IEnumerable<WordInfo> GetAllWords() => Words.Concat(ContainedLists.SelectMany(list => list.GetAllWords()));
    }
}
