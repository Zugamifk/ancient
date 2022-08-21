using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Words.Services;

namespace Words.Test
{
    public class DictionaryTest : MonoBehaviour
    {
        void Start()
        {
            var dict = new DictionaryService();
            var red = dict.GetWord("Square");
            Debug.Log($"{red.Word}: {red.Definition}");
        }
    }
}
