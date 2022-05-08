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
        //Debug.Log(_currentState.GetType());
        _currentState = _currentState.UpdateState();
    }
}