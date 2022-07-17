using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMethodButtonAttribute : PropertyAttribute
{
    public string MethodName;
    public string Label;

    public CallMethodButtonAttribute(string methodName, string label)
    {
        MethodName = methodName;
        Label = label;
    }
}
