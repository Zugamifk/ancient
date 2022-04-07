using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameDirector
{
    void SpawnAgent(string name, string position);
    void WalkToPosition(string name, string position);
}
