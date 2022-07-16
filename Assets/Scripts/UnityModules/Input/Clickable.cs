    using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Clickable : MonoBehaviour
{
    public event Action<int> Clicked;

    public void Reset()
    {
        Clicked = null;
    }

    public void Select(int mousebutton)
    {
        Clicked?.Invoke(mousebutton);
    }
}
