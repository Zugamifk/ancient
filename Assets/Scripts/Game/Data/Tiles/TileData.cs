using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileData : ScriptableObject
{
    public List<Sprite> Sprites = new List<Sprite>();
    public string North;
    public string East;
    public string South;
    public string West;
}
