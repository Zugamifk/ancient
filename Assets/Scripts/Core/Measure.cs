using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Core
{
    public struct Measure
    {
        float _value;
        public float Value => _value;

        public Measure(float value = 0)
        {
            if (value < 0)
            {
                throw new ArgumentException("Can not create measure with negative _value!");
            }
            _value = value;
        }

        public static implicit operator Measure(float amount) => new Measure(amount);
        public static Measure operator +(Measure a, Measure b) => new Measure(a._value + b.Value);
        public static Measure operator +(Measure a, float b) => new Measure(a._value + b);
        public static Measure operator +(float a, Measure b) => new Measure(a + b.Value);
        public static Measure operator -(Measure a, Measure b) => new Measure(a._value - b.Value);
        public static Measure operator -(Measure a, float b) => new Measure(a._value - b);
        public static Measure operator -(float a, Measure b) => new Measure(a - b.Value);
        public static Measure operator *(Measure a, Percentage b) => new Measure(a.Value * b);
        public static Measure operator *(Percentage a, Measure b) => new Measure(a * b.Value);
    }
}
