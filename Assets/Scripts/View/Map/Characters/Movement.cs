using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    Transform _view;

    Vector2 _positionOffset = Vector2.one;

    public Vector2 PositionOffset => _positionOffset;

    private void Awake()
    {
        _positionOffset = new Vector2(0.5f-Random.value, .5f-Random.value);
    }

    public void SetPosition(Vector3 position)
    {
        var currentPosition = transform.position;
        var dir = position - currentPosition;
        _view.transform.localRotation = Quaternion.Euler(0, dir.x < 0 ? 180 : 0, 0);
        transform.position = position;
    }
}
