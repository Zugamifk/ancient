using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Camera _camera;

    private void Awake()
    {
        _camera = GetComponentInChildren<Camera>();
    }

    public Vector3 GetWorldPosition(Vector2 screenpoint)
    {
        return _camera.ScreenToWorldPoint(screenpoint);
    }

    public Vector3 GetMouseWorldPosition()
    {
        return GetWorldPosition(Input.mousePosition);
    }

    public bool RayCast(Vector2 position, int layermask, out RaycastHit hit)
    {
        var ray = _camera.ScreenPointToRay(position);
        return Physics.Raycast(ray, out hit, float.MaxValue, layermask);
    }

    public void PanTo(Vector2 position)
    {
        transform.localPosition = position;
    }
}
