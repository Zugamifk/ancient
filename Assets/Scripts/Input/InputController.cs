using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    CameraController _deskCameraController;
    [SerializeField]
    CameraController _mapCameraController;

    MouseController _mouseController;

    void Start()
    {
        _mouseController = new MouseController(_deskCameraController, _mapCameraController);
    }

    void Update()
    {
        _mouseController.Update();
    }
}

