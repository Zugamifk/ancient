using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(CallMethodButtonAttribute))]
public class CallMethodButtonAttributeDrawer : DecoratorDrawer
{
    CallMethodButtonAttribute button => attribute as CallMethodButtonAttribute;

    public override float GetHeight()
    {
        return 16;
    }

    public override void OnGUI(Rect position)
    {
        if(GUI.Button(position, "Generate Mesh"))
        {
            Call();
        }
    }

    void Call()
    {
        Debug.Log("Pressed");
    }
}
