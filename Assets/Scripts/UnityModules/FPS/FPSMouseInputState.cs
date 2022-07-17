using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input;

namespace FPS
{
    public class FPSMouseInputState : MouseInputState
    {
        LookModel _lookModel;
        Vector3 _lastPosition;

        public FPSMouseInputState(LookModel lookModel)
        {
            _lookModel = lookModel;
            _lastPosition = UnityEngine.Input.mousePosition;
        }

        public override MouseInputState UpdateState()
        {
            var pos = UnityEngine.Input.mousePosition;
            var delta = pos - _lastPosition;
            var angles = _lookModel.LookAngles;
            angles.x = Mathf.Clamp(angles.x - delta.y * _lookModel.LookSensitivity * Time.deltaTime, -90, 90);
            angles.y = angles.y + delta.x * _lookModel.LookSensitivity * Time.deltaTime;
            angles.z = 0;
            _lookModel.LookAngles = angles;
            _lastPosition = pos;
            return this;
        }
    }
}