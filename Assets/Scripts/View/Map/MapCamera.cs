using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

[RequireComponent(typeof(Camera))]
public class MapCamera : MonoBehaviour
{
    private void Start()
    {
        var cam = GetComponent<Camera>();
        cam.transparencySortMode = TransparencySortMode.CustomAxis;
        cam.transparencySortAxis = Vector3.up;

        CreateRenderTexture(cam);
    }

    void CreateRenderTexture(Camera camera)
    {
        var rt = new RenderTexture(1024, 1024, 0);
        rt.depthStencilFormat = GraphicsFormat.None;
        rt.filterMode = FilterMode.Point;
        rt.Create();
        camera.targetTexture = rt;
    }
}
