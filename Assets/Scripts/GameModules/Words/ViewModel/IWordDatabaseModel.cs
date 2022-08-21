using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Words.ViewModel
{
    public interface IWordDatabaseModel
    {
        IWordModel GetWordModel(string word);
    }
}
