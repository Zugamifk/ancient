using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Words.Services;
using TMPro;

namespace Words.View
{
    public class WordTooltip : MonoBehaviour
    {
        [SerializeField] TMP_Text _wordText;
        [SerializeField] TMP_Text _definitionText;

        static WordTooltip _instance;
        static DictionaryService _dictionary;
        private void Awake()
        {
            _instance = this;
            _dictionary = new();
            gameObject.SetActive(false);
        }

        public static void SetShowing(bool showing)
        {
            _instance.gameObject.SetActive(showing);
        }

        public static void SetWord(string word)
        {
            var data = _dictionary.GetWord(word);
            _instance._wordText.text = data.Word;
            _instance._wordText.text = data.Definition;
        }

        public static void UpdatePosition(Vector3 position)
        {
            _instance.GetComponent<RectTransform>().position = position;
        }
    }
}
