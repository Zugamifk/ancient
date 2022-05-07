using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour, IMouseInputHandler, IModelUpdateable
{
    [SerializeField]
    CharacterCollection _agentCollection;
    [SerializeField]
    BuildingCollection _buildingCollection;
    [SerializeField]
    Transform _spawnedObjectsRoot;

    TileMapper _tilemapper;
    ViewSpawner<IBuildingModel, Building> _buildingViewSpawner = new ViewSpawner<IBuildingModel, Building>();
    Dictionary<string, Building> _buildings = new Dictionary<string, Building>();
    ViewSpawner<ICharacterModel, Movement> _characterViewSpawner = new ViewSpawner<ICharacterModel, Movement>();
    Dictionary<string, Movement> _characters = new Dictionary<string, Movement>();

    Queue<(int, int, string)> _cheatSetTileQueue = new Queue<(int, int, string)>();
    bool _isTilemapBuilt = false;

    public void SetTile(Vector3 position, string type)
    {
        var tile = _tilemapper.GetTileFromPosition(position);
        _cheatSetTileQueue.Enqueue((tile.x, tile.y, type));
    }

    private void Awake()
    {
        _tilemapper = GetComponent<TileMapper>();
    }

    /// <summary>
    /// Update with new model data for per-frame updates
    /// </summary>
    /// <param name="model"></param>
    public void UpdateFromModel(IGameModel model)
    {
        if (!_isTilemapBuilt)
        {
            RebuildTilemap(model);
        }

        UpdateBuildings(model);
        UpdateCharacters(model);

        while (_cheatSetTileQueue.Count > 0)
        {
            var (x, y, type) = _cheatSetTileQueue.Dequeue();
            model.Cheats.SetTile(x, y, type);
            _tilemapper.SetTile(x, y, model.Cheats.GameModel.Map);
        }
    }

    void RebuildTilemap(IGameModel model)
    {
        _tilemapper.BuildTilemap(model.Map);

        _isTilemapBuilt = true;
    }

    void UpdateBuildings(IGameModel model)
    {
        _buildingViewSpawner.UpdateSpawns(
            model.Map.Buildings,
            _buildings,
            b => _buildingCollection.GetPrefab(b.Name).GetComponent<Building>(),
            _spawnedObjectsRoot,
            (m, v) => v.transform.position = _tilemapper.GetWorldCenterOftile((Vector3Int)model.Map.GetBuilding(m.Id).Position));

        foreach (var b in model.Map.Buildings)
        {
            _buildings[b.Id].UpdateModel(b, model);
        }
    }

    void UpdateCharacters(IGameModel model)
    {
        _characterViewSpawner.UpdateSpawns(
            model.Characters,
            _characters,
            m => _agentCollection.GetData(m.Name).MapPrefab.GetComponent<Movement>(),
            _spawnedObjectsRoot);

        foreach (var c in model.Characters)
        {
            var character = _characters[c.Id];
            var position = _tilemapper.ModelToWorld(c.WorldPosition + character.PositionOffset);
            character.SetPosition(position);
            character.gameObject.SetActive(c.IsVisibleOnMap);
        }
    }

    MouseInputState IMouseInputHandler.GetInputState(MouseInputState state)
    {
        return new MapMouseInput(state, this);
    }
}
