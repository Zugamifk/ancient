using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileCollection
{
    Dictionary<(string, string, string, string, string), TileData> _edgeTypeToTileData = new Dictionary<(string, string, string, string, string), TileData>();
    Dictionary<string, BuildingData> _nameToBuildingData = new Dictionary<string, BuildingData>();

    public TileData GetTileData(string type, string left, string right, string top, string bottom)
    {
        return GetTileData((type, left, right, top, bottom));
    }

    public TileData GetTileData((string, string, string, string, string) key)
    {
        TileData tileData;
        if (_edgeTypeToTileData.TryGetValue(key, out tileData))
        {
            return tileData;
        }
        else
        {
            return null;
        }
    }

    public BuildingData GetBuildingData(string name)
    {
        BuildingData buildingData;
        if (_nameToBuildingData.TryGetValue(name, out buildingData))
        {
            return buildingData;
        }
        else
        {
            return null;
        }
    }

    public TileCollection(TileSprites sprites)
    {
        foreach (var td in sprites.GroundTiles)
        {
            var type = td.type.ToString();
            var left = td.left.ToString();
            var right = td.right.ToString();
            var top = td.top.ToString();
            var bottom = td.bottom.ToString();
            var key = (type, left, right, top, bottom);
            TileData tileData;
            if (!_edgeTypeToTileData.TryGetValue(key, out tileData))
            {
                tileData = new TileData(type, left, right, top, bottom);
                _edgeTypeToTileData.Add(key, tileData);
            }

            var tile = ScriptableObject.CreateInstance<Tile>();
            tile.sprite = td.sprite;
            tileData.Tiles.Add(tile);
        }

        foreach (var bd in sprites.Buildings)
        {
            var building = new BuildingData()
            {
                Name = bd.name,
                Dimensions = bd.dimensions
            };
            building.Tiles = new Tile[bd.dimensions.x * bd.dimensions.y];
            for (int i = 0; i < building.Tiles.Length; i++)
            {
                var tile = ScriptableObject.CreateInstance<Tile>();
                tile.sprite = bd.tiles[i].sprite;
                building.Tiles[i] = tile;
            }
            _nameToBuildingData.Add(building.Name, building);
        }
    }
}
