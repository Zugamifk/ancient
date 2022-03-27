using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField]
    CameraController _cameraController;

    MouseController _mouseController;

    void Start()
    {
        _mouseController = new MouseController(_cameraController);
    }

    void Update()
    {
        _mouseController.Update();
    }
}

