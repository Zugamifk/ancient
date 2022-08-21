using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Words.ViewModel
{
    public interface IWordModel
    {
        string Word { get; }
        string Definition { get; }
    }
}
