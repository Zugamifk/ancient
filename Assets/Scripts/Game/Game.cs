using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    GameModel _model = new GameModel();
    public static IGameModel Model => _game._model;

    static Game _game;
    static Queue<ICommand> _commandQueue = new Queue<ICommand>();

    Game()
    {
        _game = this;
    }

    private void Start()
    {
    }

    public static void Do(ICommand command)
    {
        _commandQueue.Enqueue(command);
    }

    private void Update()
    {
        while (_commandQueue.Count > 0)
        {
            var command = _commandQueue.Dequeue();
            command.Execute(_model);
        }
    }
}
