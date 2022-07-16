using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMouseInputHandler
{
    public MouseInputState GetInputState(MouseInputState current);
}
