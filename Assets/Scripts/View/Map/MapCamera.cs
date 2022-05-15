using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MapCamera : MonoBehaviour
{
    private void Start()
    {
        var cam = GetComponent<Camera>();
        cam.transparencySortMode = TransparencySortMode.CustomAxis;
        cam.transparencySortAxis = Vector3.up;
    }
}
