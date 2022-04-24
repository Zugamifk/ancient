using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterModel
{
    string Name { get; }
    Vector2 WorldPosition { get; }
    bool IsVisibleOnMap { get; }
}
