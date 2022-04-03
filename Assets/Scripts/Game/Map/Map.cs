using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Map : MonoBehaviour, IMouseInputHandler
{
    [SerializeField]
    BuildingCollection _buildingCollection;

    TileMapper _tilemapper;
    List<Building> _buildings = new List<Building>();

    public void SetTile(Vector3 position, string type)
    {
        _tilemapper.SetTile(position, type);
    }

    private void Start()
    {
        _tilemapper = GetComponent<TileMapper>();
        GenerateMap();
    }

    void GenerateMap()
    {
        var hq = AddBuilding(Vector3.zero, Names.Buildings.Manor);
        var house = AddBuilding(new Vector2(5,2), Names.Buildings.House);
        ConnectBuildings(hq, house);
    }

    Building AddBuilding(Vector3 position, string name)
    {
        _tilemapper.PlaceBuilding(position, name);
        var prefab = Instantiate(_buildingCollection.NameToBuilding[name]);
        prefab.transform.position = position;
        var building = prefab.GetComponent<Building>();
        _buildings.Add(building);
        return building;
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
