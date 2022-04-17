using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INarrativeState
{
    public string Name { get; }
    string UpdateState(IGameModel model);
}
