using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative
{
    public interface INarrativeState
    {
        public string Name { get; }
        void EnterState(IGameModel model);
        string UpdateState(IGameModel model);
        void ExitState(IGameModel model);

    }
}