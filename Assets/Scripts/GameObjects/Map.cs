using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    [SerializeField]
    Tilemap _tilemap;

    TileMapper _tilemapper;

    private void Start()
    {
        _tilemapper = GetComponent<TileMapper>();
    }

    public MapMouseInput StartMapping()
    {
        return new MapMouseInput(_tilemap);
    }
}
