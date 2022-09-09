using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ViewModel
{
    public interface IMapModel : IIdentifiable, IKeyHolder
    {
        IGridModel Grid { get; }
        ISet<Guid> CharacterIds { get; }
    }
}