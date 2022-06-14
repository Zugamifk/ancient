using Map.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Map.Commands
{
    public interface IMapModelMutator
    {
        void SetMapHandle(IMutableMapHandle mapHandle);
    }
}
