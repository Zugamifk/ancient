//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public abstract class NarrativeState : INarrativeState
//{
//    public abstract string Name { get; }
//    public virtual void EnterState(IGameModel model) { }
//    public abstract string UpdateState(IGameModel model);
//    public virtual void ExitState(IGameModel model) { }
//}

//public abstract class NarrativeState<T> : NarrativeState where T: NarrativeStepData
//{
//    public sealed override string Name => Data.Name;
//    public T Data;
//    public ICommandService Commands;
//}
