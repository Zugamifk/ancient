using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Words.Data;
using Words.Model;
using Words.ViewModel;

namespace Words.Services
{
    public class DictionaryService
    {
        static WordDatabaseModel _wordDatabase;

        public DictionaryService()
        {
            if(_wordDatabase == null)
            {
                InitializeModel();
            }
        }

        void InitializeModel()
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
                    _wordDatabase.Words.Add(CreateKeyFromWord(word.Word), model);
                }
            }
        }

        public IWordModel GetWord(string word)
        {
            return _wordDatabase.GetWordModel(CreateKeyFromWord(word));
        }

        public bool ContainsWord(string word)
        {
            return _wordDatabase.Words.ContainsKey(CreateKeyFromWord(word));
        }

        string CreateKeyFromWord(string word) => word.ToLower();
    }
}
