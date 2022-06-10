using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.ViewModel
{
    public interface IMapModel
    {
        IGridModel Grid { get; }
    }
}