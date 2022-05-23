using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Core
{
    public struct Measure
    {
        float _amount;
        public float Amount => _amount;

        public Measure(float amount = 0)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Can not create measure with negative amount!");
            }
            _amount = amount;
        }

        public static implicit operator Measure(float amount) => new Measure(amount);
        public static Measure operator +(Measure a, Measure b) => new Measure(a._amount + b.Amount);
        public static Measure operator +(Measure a, float b) => new Measure(a._amount + b);
        public static Measure operator +(float a, Measure b) => new Measure(a + b.Amount);
        public static Measure operator -(Measure a, Measure b) => new Measure(a._amount - b.Amount);
        public static Measure operator -(Measure a, float b) => new Measure(a._amount - b);
        public static Measure operator -(float a, Measure b) => new Measure(a - b.Amount);
        public static Measure operator *(Measure a, Percentage b) => new Measure(a.Amount * b);
        public static Measure operator *(Percentage a, Measure b) => new Measure(a * b.Amount);
    }
}
