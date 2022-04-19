using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    [field: SerializeField]
    public string Name { get; set; }
    [SerializeField]
    Transform _view;

    public void SetPosition(Vector3 position)
    {
        var currentPosition = transform.position;
        var dir = position - currentPosition;
        _view.transform.localRotation = Quaternion.Euler(0, dir.x < 0 ? 180 : 0, 0);
        transform.position = position;
    }
}
