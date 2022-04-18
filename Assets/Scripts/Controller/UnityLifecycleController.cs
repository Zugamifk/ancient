using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityLifecycleController : MonoBehaviour
{
    public event Action OnUpdate;

    private void Update()
    {
        OnUpdate?.Invoke();
    }
}
