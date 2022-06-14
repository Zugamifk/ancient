using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    static Dictionary<string, CameraController> _nameToController = new Dictionary<string, CameraController>();

    public static bool TryGetCamera(string name, out CameraController cameraController, bool warnIfNull = false)
    {
        if(_nameToController.TryGetValue(name, out cameraController))
        {
            return true;
        }

        if (warnIfNull)
        {
            Debug.LogWarning($"No camera controller named \'{name}\' registered!");
        }

        return false;
    }

    [SerializeField]
    string _name;

    Camera _camera;

    public Camera Camera => _camera;

    private void Awake()
    {
        _camera = GetComponentInChildren<Camera>();
        if (string.IsNullOrEmpty(_name))
        {
            throw new System.InvalidOperationException($"Camera {this} name is null!");
        }
        _nameToController[_name] = this;
    }

    public Vector3 GetWorldPosition(Vector2 screenpoint)
    {
        return _camera.ScreenToWorldPoint(screenpoint);
    }

    public Vector3 GetMouseWorldPosition()
    {
        return GetWorldPosition(Input.mousePosition);
    }

    public bool RayCast(Vector2 position, out RaycastHit hit)
    {
        var ray = _camera.ScreenPointToRay(position);
        return Physics.Raycast(ray, out hit, float.MaxValue, 1 << gameObject.layer);
    }

    public void PanTo(Vector2 position)
    {
        transform.localPosition = position;
    }
}
