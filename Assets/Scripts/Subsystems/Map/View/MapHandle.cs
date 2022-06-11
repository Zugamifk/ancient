using Map.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.View
{
    public interface IMapHandle
    {
        IMapModel Map { get; }
    }
}
