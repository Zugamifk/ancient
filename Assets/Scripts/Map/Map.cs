using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour, IMouseInputHandler
{
    [SerializeField]
    CameraController _cameraController;
    [SerializeField]
    Tilemap _tilemap;

    TileMapper _tilemapper;


    public void SetTile(Vector3 position, string type)
    {
        var cell = _tilemap.WorldToCell(position);
        _tilemapper.SetTile(cell.x, cell.y, type);
    }

    private void Start()
    {
        _tilemapper = GetComponent<TileMapper>();
        GenerateMap();
    }

    void GenerateMap()
    {
        _tilemapper.PlaceBuilding(0, 0, Tiles.Buildings.Base);
        _tilemapper.PlaceBuilding(5, 2, Tiles.Buildings.Mystery);
        _tilemapper.PlaceBuilding(3, -3, Tiles.Buildings.Tower);
    }

    MouseInputState IMouseInputHandler.GetInputState()
    {
        return new MapMouseInput(this, _cameraController);
    }

    
}
