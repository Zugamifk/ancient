using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class MouseController
{
    MouseInputState _currentState;

    public MouseController(CameraController cameraController)
    {
        var context = new InputStateContext()
        {
            CameraController = cameraController
        };
        _currentState = new IdleMouseInputState(context);
    }


    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentState = _currentState.MouseDown();
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