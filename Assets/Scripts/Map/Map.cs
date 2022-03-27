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

    private void Start()
    {
        _tilemapper = GetComponent<TileMapper>();
    }

    public MouseInputState GetInputState()
    {
        return new MapMouseInput(this, _cameraController);
    }

    public void SetTile(Vector3 position, string type)
    {
        var cell = _tilemap.WorldToCell(position);
        _tilemapper.SetTile(cell.x, cell.y, type);
    }
}
