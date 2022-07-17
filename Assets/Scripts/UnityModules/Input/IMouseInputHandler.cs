using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Input
{
    public interface IMouseInputHandler
    {
        public MouseInputState GetInputState(MouseInputState current);
    }
}