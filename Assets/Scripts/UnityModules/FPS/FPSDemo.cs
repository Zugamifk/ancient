using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input;

namespace FPS
{
    public class FPSDemo : MonoBehaviour
    {
        [SerializeField]
        Transform _lookRoot;

        LookModel _look = new();

        void Start()
        {
            var state = new FPSMouseInputState(_look);
            InputController.SetMouseInputState(state);
        }

        private void Update()
        {
            _lookRoot.rotation = Quaternion.Euler(_look.LookAngles);
        }
    }
}