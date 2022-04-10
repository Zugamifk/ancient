using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public interface ITileBuilder
{
    Tile GetTile(string type, string left, string top, string right, string bottom);
}
