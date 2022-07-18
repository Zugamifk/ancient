using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MeshGenerator.Editor
{
    public interface IMeshGeneratorEditor
    {
        void SetGenerator(IMeshGenerator generator);
        void DrawSceneGUI(Transform rootTransform);
        void DrawInspectorGUI();
    }
}
