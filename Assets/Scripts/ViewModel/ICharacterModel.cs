using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICharacterModel : IIdentifiable, IKeyHolder, IMapPositionable
{
    bool IsVisibleOnMap { get; }
}
