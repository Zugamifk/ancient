using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour
{
    [SerializeField]
    CharacterCollection _characterCollection;
    [SerializeField]
    BuildingCollection _buildingCollection;
    [SerializeField]
    Transform _spawnedObjectsRoot;

    TileMapper _tileMapper;
    ViewSpawner<IBuildingModel, Building> _buildingViewSpawner;
    ViewSpawner<ICharacterModel, Character> _characterViewSpawner;

    Queue<(int, int, string)> _cheatSetTileQueue = new Queue<(int, int, string)>();
    bool _isTilemapBuilt = false;

    public void SetTile(Vector3 position, string type)
    {
        var tile = _tileMapper.GetTileFromPosition(position);
        _cheatSetTileQueue.Enqueue((tile.x, tile.y, type));
    }

    private void Awake()
    {
        _tileMapper = GetComponent<TileMapper>();

        _characterViewSpawner = new CharacterViewSpawner(_characterCollection, _spawnedObjectsRoot);
        _buildingViewSpawner = new BuildingViewSpawner(_buildingCollection, _spawnedObjectsRoot);
    }

    /// <summary>
    /// Update with new model data for per-frame updates
    /// </summary>
    /// <param name="model"></param>
    public void Update()
    {
        if (!_isTilemapBuilt)
        {
            RebuildTilemap();
            //model.Map.SetTileMapTransformer(_tileMapper);
        }

        //while (_cheatSetTileQueue.Count > 0)
        //{
        //    var (x, y, type) = _cheatSetTileQueue.Dequeue();
        //    model.Cheats.SetTile(x, y, type);
        //    _tileMapper.SetTile(x, y, model.Cheats.GameModel.Map);
        //}
    }

    public Vector2Int GetTileFromWorldPosition(Vector3 worldPosition)
    {
        return (Vector2Int)_tileMapper.GetTileFromPosition(worldPosition);
    }

    void RebuildTilemap()
    {
        _tileMapper.BuildTilemap(Game.Model.Map);

        _isTilemapBuilt = true;
    }
}
