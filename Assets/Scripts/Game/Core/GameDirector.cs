using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour, IGameDirector
{
    GameController _controller;

    public GameDirector(GameController controller)
    {
        _controller = controller;
    }

    public void SpawnAgent(string name, string position)
    {
        _controller.AddAgent(name);
    }

    public void WalkToPosition(string name, string position)
    {
        _controller.SetAgentPath(name, Names.Buildings.Manor, position);
    }
}
