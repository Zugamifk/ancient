using System.Collections;
using System.Collections.Generic;
using MeshGenerator.Editor;
using MeshGenerator;
using UnityEditor;
using PortalDefense.Data;
namespace PortalDefense.Services.Editor
{
    [MeshGeneratorEditor(typeof(CardFrameMeshGenerator))]
    public class CardFrameMeshGeneratorEditor : MeshGeneratorWithWireFrameEditor<CardFrameMeshGenerator, CardFrameMeshGeneratorData>
    {
        
    }
}
