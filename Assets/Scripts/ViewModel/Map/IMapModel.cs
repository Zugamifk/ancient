using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapModel : IIdentifiable, IKeyHolder
{
    IGridModel Grid { get; }
    ISet<Guid> CharacterIds { get; }
}
