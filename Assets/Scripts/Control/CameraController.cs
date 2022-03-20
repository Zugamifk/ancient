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

    public MouseListener GetMouseTarget(Vector2 position)
    {
        RaycastHit hit;
        if (Physics.Raycast(_camera.ScreenPointToRay(position), out hit))
        {
            var listener = hit.collider.GetComponent<MouseListener>();
            if(listener != null)
            {
                return listener;
            }
        }

        return null;
    }
}
