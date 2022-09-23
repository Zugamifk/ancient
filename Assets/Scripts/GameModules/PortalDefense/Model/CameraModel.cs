using PortalDefense.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PortalDefense.Model
{
    public class CameraModel : ICameraModel
    {
        public Vector2 Position { get; set; }
        public float Height { get; set; }
        public float Angle { get; set; }
        public float MoveSpeed { get; set; }
        public float RotateSpeed { get; set; }
    }
}
