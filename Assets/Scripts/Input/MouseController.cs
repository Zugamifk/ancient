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
        _currentState = _currentState.UpdateState();
    }
}