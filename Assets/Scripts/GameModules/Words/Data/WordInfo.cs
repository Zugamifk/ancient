using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Words.Data
{
    public class WordInfo : ScriptableObject
    {
        [SerializeField] string _word;
        [SerializeField, TextArea] string _definition;

        public string Word => _word;
        public string Definition => _definition;
    }
}
