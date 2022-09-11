using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalDefense.Model
{
    public class MovementModel
    {
        public Vector3 CurrentPosition;
        public PathNodeModel CurrentNode { get; set; }
    }
}
