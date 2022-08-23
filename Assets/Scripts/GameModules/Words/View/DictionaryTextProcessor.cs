using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Words.Services;

namespace Words.View
{
    public class DictionaryTextProcessor : MonoBehaviour
    {
        static DictionaryService _dictionary;

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
                    CreateWordSelectable(verts, i, w.Length * 4);
                }
                i += w.Length * 4;
            }
        }

        void CreateWordSelectable(Vector3[] verts, int startIndex, int length)
        {
            Debug.Log($"{verts.Length} {startIndex} {length}");
            float minX=0, maxX = 0, minY = 0, maxY = 0;
            for(int i=startIndex;i<startIndex+length;i++)
            {
                var v = verts[i];
                minX = Mathf.Min(minX, v.x);
                maxX = Mathf.Max(maxX, v.x);
                minY = Mathf.Min(minY, v.y);
                maxY = Mathf.Max(maxY, v.y);
            }
            Debug.Log($"{minX}-{maxX}   {minY}-{maxY}");
        }
    }
}
