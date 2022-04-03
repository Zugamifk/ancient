using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour, IMouseInputHandler
{
    [SerializeField]
    BuildingCollection _buildingCollection;

    TileMapper _tilemapper;
    Dictionary<string, Building> _buildings = new Dictionary<string, Building>();

    public void SetTile(Vector3 position, string type)
    {
        _tilemapper.SetTile(position, type);
    }

    private void Start()
    {
        _tilemapper = GetComponent<TileMapper>();
    }

    public void UpdateFromModel(IMapModel model)
    {
        foreach(var b in model.Buildings)
        {
            Building building;
            if(!_buildings.TryGetValue(b.Name, out building))
            {
                building = SpawnBuilding(b.Name);
            }

            PositionBuilding(building, b.Position);
        }
    }

    Building SpawnBuilding(string name)
    {
        var prefab = Instantiate(_buildingCollection.NameToBuilding[name]);
        var building = prefab.GetComponent<Building>();
        _buildings.Add(name, building);
        return building;
    }

    void PositionBuilding(Building building, Vector2Int gridPosition)
    {
        var position = new Vector3(gridPosition.x, gridPosition.y, 0);
        building.transform.position = position;
    }

    void ConnectBuildings(Building start, Building end)
    {
        _tilemapper.CreateRoad(start.EntrancePosition, end.EntrancePosition);
    }

    MouseInputState IMouseInputHandler.GetInputState(MouseInputState state)
    {
        return new MapMouseInput(state, this);
    }
}
