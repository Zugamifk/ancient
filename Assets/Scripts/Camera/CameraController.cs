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

    public GameObject RayCast(Vector2 position)
    {
        var ray = _camera.ScreenPointToRay(position);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            return hit.transform.gameObject;
        }

        return null;
    }
}
