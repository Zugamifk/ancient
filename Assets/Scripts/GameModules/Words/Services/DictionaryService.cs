using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Words.Data;
using Words.Model;
using Words.ViewModel;

namespace Words.Services
{
    public class DictionaryService : MonoBehaviour
    {
        static WordDatabaseModel _wordDatabase;

        public DictionaryService()
        {
            if(_wordDatabase == null)
            {
                InitializeModel();
            }
        }

        static void InitializeModel()
        {
            var data = DataService.GetData<WordListCollection>();
            _wordDatabase = new();
            foreach(var list in data.AllLists)
            {
                foreach(var word in list.Words)
                {
                    var model = new WordModel()
                    {
                        Word = word.Word,
                        Definition = word.Definition
                    };
                    _wordDatabase.Words.Add(word.Word, model);
                }
            }
        }

        public IWordModel GetWord(string word)
        {
            return _wordDatabase.GetWordModel(word);
        }
    }
}
