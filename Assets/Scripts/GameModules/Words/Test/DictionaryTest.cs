using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Words.Services;
using Words.Data;

namespace Words.Test
{
    public class DictionaryTest : MonoBehaviour
    {
        [SerializeField] DataReferences _data;
        
        void Start()
        {
            var dict = new DictionaryService();
            var red = dict.GetWord("Square");
            Debug.Log($"{red.Word}: {red.Definition}");
        }
    }
}
