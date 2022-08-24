using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Words.Services;

namespace Words.View
{
    public class DictionaryTextProcessor : MonoBehaviour
    {
        [SerializeField] SelectableWord _selecatbleWordTemplate;

        struct SelectableData
        {
            public string word;
            public Vector3 p0;
            public Vector3 p1;
            public Vector3 p2;
            public Vector3 p3;
        }

        static DictionaryService _dictionary;
        Dictionary<string, SelectableWord> _wordToSelectable = new();
        Queue<SelectableData> _selectablesToSpawn = new();

        TMP_Text _tmp;
        void Start()
        {
            if(_dictionary == null)
            {
                _dictionary = new();
            }

            _tmp = GetComponent<TMP_Text>();
            TMPro_EventManager.TEXT_CHANGED_EVENT.Add(OnTextChanged);
        }

        private void Update()
        {
            while(_selectablesToSpawn.Count>0)
            {
                var data = _selectablesToSpawn.Dequeue();
                var selectable = Instantiate(_selecatbleWordTemplate);
                selectable.transform.SetParent(transform.parent);
                selectable.SetCorners(data.p0, data.p1, data.p2, data.p3);
                _wordToSelectable.Add(data.word, selectable);
            }
        }

        void OnTextChanged(Object obj)
        {
            if(obj == _tmp)
            {
                ProcessText();
            }
        }

        void ProcessText()
        {
            var text = _tmp.text;
            var verts = _tmp.mesh.vertices;
            var words = text.Split(" ");
            int i = 0;
            foreach(var w in words)
            {
                if (_dictionary.ContainsWord(w))
                {
                    CreateWordSelectable(w, verts, i, w.Length * 4);
                }
                i += w.Length * 4;
            }
        }

        void CreateWordSelectable(string word, Vector3[] verts, int startIndex, int length)
        {
            float minX=0, maxX = 0, minY = 0, maxY = 0;
            for(int i=startIndex;i<startIndex+length;i++)
            {
                var v = verts[i];
                minX = Mathf.Min(minX, v.x);
                maxX = Mathf.Max(maxX, v.x);
                minY = Mathf.Min(minY, v.y);
                maxY = Mathf.Max(maxY, v.y);
            }

            var data = new SelectableData()
            {
                word = word,
                p0 = new Vector3(minX, minY, 0),
                p1 = new Vector3(minX, maxY, 0),
                p2 = new Vector3(maxX, maxY, 0),
                p3 = new Vector3(maxX, minY, 0)
            };
            _selectablesToSpawn.Enqueue(data);
        }
    }
}
