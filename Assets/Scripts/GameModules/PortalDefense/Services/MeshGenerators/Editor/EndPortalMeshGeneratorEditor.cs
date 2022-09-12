using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeshGenerator.Editor;
using MeshGenerator;
using UnityEditor;
using PortalDefense.Data;

namespace PortalDefense.Services.Editor
{
    [MeshGeneratorEditor(typeof(EndPortalMeshGenerator))]
    public class EndPortalMeshGeneratorEditor : MeshGeneratorWithWireFrameEditor<EndPortalMeshGenerator, EndPortalMeshGeneratorData>
    {
        
    }
}
