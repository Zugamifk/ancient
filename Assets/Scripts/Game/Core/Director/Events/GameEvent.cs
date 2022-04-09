using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEvent
{
    public virtual void OnStarted(Director director, IGameModel model) { }
    public abstract void Execute(Director director, IGameModel model, System.Action<string> onCompleted);
}

public abstract class GameEvent<T> : GameEvent where T: NarrativeStepData
{
    public T Data;
}
