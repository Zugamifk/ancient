using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    [SerializeField]
    Map _map;

    GameController _controller;

    private void Start()
    {
        _controller = new GameController();
    }

    void DemoInit()
    {
        //_controller.AddBuilding(tiles)
        //var hq = AddBuilding(Vector3.zero, Tiles.Buildings.Manor);
        //var house = AddBuilding(new Vector2(5, 2), Tiles.Buildings.House);
        //ConnectBuildings(hq, house);
    }
}
