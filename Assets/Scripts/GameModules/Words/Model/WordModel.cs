using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Words.ViewModel;

namespace Words.Model
{
    public class WordModel : IWordModel
    {
        public string Word { get; set; }

        public string Definition { get; set; }
    }
}
