using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MeshGenerator.Editor;
using MeshGenerator;
using PortalDefense.Data;

namespace PortalDefense.Services.Editor
{
    [MeshGeneratorEditor(typeof(ArrowTowerMeshGenerator))]
    public class ArrowTowerMeshGeneratorEditor : MeshGeneratorWithWireFrameEditor<ArrowTowerMeshGenerator, ArrowTowerMeshGeneratorData>
    {
        
    }
}
