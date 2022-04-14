using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class MouseController
{
    MouseInputState _currentState;

    public MouseController(CameraController deskCameraController, CameraController mapCameraController)
    {
        var context = new InputStateContext()
        {
            DeskCameraController = deskCameraController,
            MapCameraController = mapCameraController
        };
        _currentState = new IdleMouseInputState(context);
    }


    public void Update()
    {
        _currentState = _currentState.UpdateState();
    }
}