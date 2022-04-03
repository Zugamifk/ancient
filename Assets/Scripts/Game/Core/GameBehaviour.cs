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
}
