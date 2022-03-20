using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    MouseInputState _currentState;

    private void Awake()
    {
        _currentState = new IdleMouseInputState();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentState =_currentState.MouseDown();
        } 

        if (Input.GetMouseButton(0))
        {
            _currentState = _currentState.Drag();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _currentState = _currentState.MouseUp();
        }
    }
}
