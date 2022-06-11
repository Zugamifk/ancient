using Map.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.Commands
{
    public interface IMapCommand
    {
        MapModel MapModel { set; }
    }
}
