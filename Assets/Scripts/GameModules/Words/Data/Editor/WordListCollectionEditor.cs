using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace Words.Data
{
    [CustomEditor(typeof(WordListCollection))]
    public class WordListCollectionEditor : Editor
    {
        const string WORDS_DATA_PATH = "Assets/Data/Words";

        SerializedObject _currentWordList;
        bool _wordListShowContained;

        public override void OnInspectorGUI()
        {
            if (_currentWordList != null)
            {
                DrawWordList();
            } else
            {
                DrawWordListCollection(serializedObject.FindProperty("_allLists"));
            }
        }

        void DrawWordListCollection(SerializedProperty allListsProp)
        {
            serializedObject.Update();
            EditorGUI.BeginChangeCheck();
            for(int i=0;i<allListsProp.arraySize;i++)
            {
                using(new EditorGUILayout.HorizontalScope("box"))
                {
                    var listProp = allListsProp.GetArrayElementAtIndex(i);
                    var listSerObj = new SerializedObject((WordList)listProp.objectReferenceValue);
                    var categoryProp = listSerObj.FindProperty("_category");
                    EditorGUILayout.LabelField(categoryProp.stringValue);

                    if(GUILayout.Button("Edit"))
                    {
                        _currentWordList = listSerObj;
                    }

                    if(GUILayout.Button("Delete"))
                    {
                        // delete
                    }
                }
            }

            if(GUILayout.Button("Add New"))
            {
                allListsProp.arraySize++;
                var newListProp = allListsProp.GetArrayElementAtIndex(allListsProp.arraySize - 1);
                newListProp.objectReferenceValue = CreateNewWordList();
            }
            if(EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }
        }

        void DrawWordList()
        {
            EditorGUILayout.BeginHorizontal("box");
            _wordListShowContained = GUILayout.Toggle(_wordListShowContained, "Show Contained Lists");
            
            if (GUILayout.Button("Back To Collection"))
            {
                _currentWordList = null;
                return;
            }
            EditorGUILayout.EndHorizontal();

            _currentWordList.Update();
            EditorGUI.BeginChangeCheck();

            if(_wordListShowContained)
            {
                var containedProp = _currentWordList.FindProperty("_containedLists");
                EditorGUILayout.PropertyField(containedProp);
            }

            var categoryProp = _currentWordList.FindProperty("_category");
            var currentCategory = categoryProp.stringValue;
            EditorGUILayout.PropertyField(categoryProp);
            if (!string.IsNullOrEmpty(categoryProp.stringValue)
                && categoryProp.stringValue != currentCategory)
            {
                _currentWordList.ApplyModifiedProperties();
                var currentPath = AssetDatabase.GetAssetPath(_currentWordList.targetObject);
                var newPath = categoryProp.stringValue + ".asset";
                AssetDatabase.RenameAsset(currentPath, newPath);
            }

            var wordsProp = _currentWordList.FindProperty("_words");
            for(int i=0;i< wordsProp.arraySize;i++)
            {
                EditorGUI.BeginChangeCheck();
                var wordSerObj = new SerializedObject(wordsProp.GetArrayElementAtIndex(i).objectReferenceValue);
                EditorGUILayout.BeginVertical("box");
                var wordProp = wordSerObj.FindProperty("_word");
                var currentWord = wordProp.stringValue;
                EditorGUILayout.PropertyField(wordSerObj.FindProperty("_word"));
                if (!string.IsNullOrEmpty(wordProp.stringValue)
                    && wordProp.stringValue != currentWord)
                {
                    wordSerObj.ApplyModifiedProperties();
                    var currentPath = AssetDatabase.GetAssetPath(wordSerObj.targetObject);
                    var newPath = wordProp.stringValue + ".asset";
                    AssetDatabase.RenameAsset(currentPath, newPath);
                }
                EditorGUILayout.PropertyField(wordSerObj.FindProperty("_definition"));
                EditorGUILayout.EndHorizontal();
                if (EditorGUI.EndChangeCheck())
                {
                    wordSerObj.ApplyModifiedProperties();
                }
            }

            if (GUILayout.Button("Add New"))
            {
                wordsProp.arraySize++;
                var newWordProp = wordsProp.GetArrayElementAtIndex(wordsProp.arraySize - 1);
                newWordProp.objectReferenceValue = CreateNewWordInfo();
            }

            if (EditorGUI.EndChangeCheck())
            {
                _currentWordList.ApplyModifiedProperties();
            }
        }

        WordList CreateNewWordList()
        {
            var list = ScriptableObject.CreateInstance<WordList>();

            var newListPath = Path.Combine(WORDS_DATA_PATH, "New WordList.asset");
            newListPath = AssetDatabase.GenerateUniqueAssetPath(newListPath);
            AssetDatabase.CreateAsset(list, newListPath);
            AssetDatabase.ImportAsset(newListPath);

            return list;
        }

        WordInfo CreateNewWordInfo()
        {
            var word = ScriptableObject.CreateInstance<WordInfo>();

            var newWordPath = Path.Combine(WORDS_DATA_PATH, "New WordInfo.asset");
            newWordPath = AssetDatabase.GenerateUniqueAssetPath(newWordPath);
            AssetDatabase.CreateAsset(word, newWordPath);
            AssetDatabase.ImportAsset(newWordPath);

            return word;
        }
    }
}
