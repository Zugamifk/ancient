using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalDefense.ViewModel
{
    public interface ICameraModel
    {
        Vector2 Position { get; }
        float Height { get; }
        float Angle { get; }
        float MoveSpeed { get; }
        float RotateSpeed { get; }
    }
}
