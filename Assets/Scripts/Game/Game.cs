using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    GameModel _model = new GameModel();

    static Game _game;
    static Queue<ICommand> _commandQueue = new Queue<ICommand>();
    public static IGameModel Model => _game._model;

    public static void Do(ICommand command)
    {
        _commandQueue.Enqueue(command);
    }

    Game()
    {
        _game = this;
    }

    private void Start()
    {
        SimpleNarrativeTest.Init("ReceiveLetter");
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
