using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterModel : IIdentifiable, IMapPositionable, IKeyHolder
{
    bool IsVisibleOnMap { get; }
}
