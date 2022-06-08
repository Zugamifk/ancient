using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    static Dictionary<string, CameraController> _nameToController = new Dictionary<string, CameraController>();

    public static CameraController TryGetCamera(string name)
    {
        if(_nameToController.TryGetValue(name, out CameraController controller))
        {
            return controller;
        }

        return null;
    }

    [SerializeField]
    string _name;

    Camera _camera;

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
        return Physics.Raycast(ray, out hit, float.MaxValue, gameObject.layer);
    }

    public void PanTo(Vector2 position)
    {
        transform.localPosition = position;
    }
}
