using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectListener : MonoBehaviour, ISelectable
{
    public delegate MouseInputState OnSelect(MouseInputState current);
    public event OnSelect Selected;
    
    public MouseInputState Select(MouseInputState current)
    {
        return Selected?.Invoke(current);
    }
}
