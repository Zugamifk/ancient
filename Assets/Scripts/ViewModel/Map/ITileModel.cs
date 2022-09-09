using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewModel
{
    public interface ITileModel
    {
        string Type { get; }
        int MoveCost { get; }
    }
}