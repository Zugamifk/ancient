using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Fluids
{
    public struct FluidMeasure
    {
        float _measure;
        public float Measure => _measure;

        public FluidMeasure(float amount = 0)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Can not create measure with negative value!");
            }
            _measure = amount;
        }

        public static implicit operator FluidMeasure(float amount) => new FluidMeasure(amount);
        public static FluidMeasure operator +(FluidMeasure a, FluidMeasure b) => new FluidMeasure(a._measure + b.Measure);
        public static FluidMeasure operator +(FluidMeasure a, float b) => new FluidMeasure(a._measure + b);
        public static FluidMeasure operator +(float a, FluidMeasure b) => new FluidMeasure(a + b.Measure);
        public static FluidMeasure operator -(FluidMeasure a, FluidMeasure b) => new FluidMeasure(a._measure - b.Measure);
        public static FluidMeasure operator -(FluidMeasure a, float b) => new FluidMeasure(a._measure - b);
        public static FluidMeasure operator -(float a, FluidMeasure b) => new FluidMeasure(a - b.Measure);
        public static FluidMeasure operator *(FluidMeasure a, Percentage b) => new FluidMeasure(a.Measure * b);
        public static FluidMeasure operator *(Percentage a, FluidMeasure b) => new FluidMeasure(a * b.Measure);
    }
}
