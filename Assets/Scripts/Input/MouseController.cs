using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class MouseController
{
    MouseInputState _currentState;

    public MouseController(CameraController cameraController)
    {
        _currentState = new IdleMouseInputState(cameraController);
    }


    public void Update()
    {
        if (UnityEngine.Input.GetMouseButtonDown(0))
        {
            _currentState = _currentState.MouseDown();
        }

        if (UnityEngine.Input.GetMouseButton(0))
        {
            _currentState = _currentState.Drag();
        }

        if (UnityEngine.Input.GetMouseButtonUp(0))
        {
            _currentState = _currentState.MouseUp();
        }
    }
}