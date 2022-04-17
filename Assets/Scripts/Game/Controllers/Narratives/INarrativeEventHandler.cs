using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INarrativeEventHandler
{
    void SpawnAgent(string character, string position);
    void WalkToPosition(string character, string destination);
}
