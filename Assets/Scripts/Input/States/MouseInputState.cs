using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInputState
{
    protected InputStateContext _context;

    protected MouseInputState(InputStateContext context)
    {
        _context = context;
    }

    protected MouseInputState(CameraController cameraController)
        : this(new InputStateContext() { CameraController = cameraController })
    { }

    public virtual MouseInputState Drag()
    {
        return this;
    }

    public virtual MouseInputState MouseDown()
    {
        return this;
    }

    public virtual MouseInputState MouseUp()
    {
        return this;
    }
}
