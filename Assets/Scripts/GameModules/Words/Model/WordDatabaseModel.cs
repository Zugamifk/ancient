using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Words.ViewModel;

namespace Words.Model
{
    public class WordDatabaseModel : IWordDatabaseModel
    {
        public Dictionary<string, WordModel> Words = new();

        IWordModel IWordDatabaseModel.GetWordModel(string word) => Words[word];
    }
}
