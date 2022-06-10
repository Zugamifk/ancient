using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITileModel
{
    string Type { get; }
    int MoveCost { get; }
}
