//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using UnityEngine;

//class NarrativeController
//{
//    NarrativeCollection _collection;
//    ICommandService _commands;

//    public NarrativeController(NarrativeCollection collection, ICommandService commands)
//    {
//        _collection = collection;
//        _commands = commands;
//    }

//    public void StartNarrative(string name, GameModel model)
//    {
//        var narrative = BuildNarrative(name);
//        model.Narratives.Add(name, narrative);
//        narrative.CurrentState.EnterState(model);
//    }

//   public void Update(NarrativeModel narrative, GameModel model)
//   {
//        if (narrative.CurrentState == null) return;

//        var next = narrative.CurrentState.UpdateState(model);
//        if (string.IsNullOrEmpty(next))
//        {
//            narrative.CurrentState.ExitState(model);
//            narrative.CurrentState = null;
//        } else if (next!=narrative.CurrentState.Name) 
//        {
//            var data = _collection.GetNarrative(narrative.Name);
//            var stateData = data.Steps.First(s => s.Name == next);
//            narrative.CurrentState.ExitState(model);
//            narrative.CurrentState = BuildNarrativeState(stateData);
//            narrative.CurrentState.EnterState(model);
//        }
//    }

//    
//}
