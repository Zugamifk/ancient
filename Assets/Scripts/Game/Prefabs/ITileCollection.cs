using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITileCollection
{
    ITileData GetTileData(string type, string left, string right, string top, string bottom);
}
