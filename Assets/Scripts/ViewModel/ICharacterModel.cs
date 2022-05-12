using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterModel : IIdentifiable, IMapPositionable
{
    string Name { get; }
    Vector2 Position { get; }
    bool IsVisibleOnMap { get; }
}
