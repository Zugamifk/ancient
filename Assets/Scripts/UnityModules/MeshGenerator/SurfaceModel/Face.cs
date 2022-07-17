using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator
{
    public class Face
    {
        /// <summary>
        /// This face represents the outside boundary of an open mesh.
        /// </summary>
        public static readonly Face Outside = new();

        public HalfEdge HalfEdge;
    }
}
