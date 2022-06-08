using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    MouseController _mouseController;

    void Start()
    {
        _mouseController = new MouseController();
    }

    void Update()
    {
        _mouseController.Update();
    }
}

