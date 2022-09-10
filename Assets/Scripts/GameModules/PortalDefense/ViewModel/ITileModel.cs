using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalDefense.ViewModel
{
    public interface ITileModel
    {
        bool HasPath { get; }
        int Height { get; }
    }
}
