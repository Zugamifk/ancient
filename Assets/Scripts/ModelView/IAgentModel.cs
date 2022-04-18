using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAgentModel
{
    string Name { get; }
    Vector2 WorldPosition { get; }

}
