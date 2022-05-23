using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Fluids
{
    public struct FluidMeasure
    {
        float _amount;
        public float Amount => _amount;

        public FluidMeasure(float amount = 0)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Can not create measure with negative value!");
            }
            _amount = amount;
        }

        public static FluidMeasure operator +(FluidMeasure a, FluidMeasure b) => new FluidMeasure(a._amount + b.Amount);
        public static FluidMeasure operator +(FluidMeasure a, float b) => new FluidMeasure(a._amount + b);
        public static FluidMeasure operator +(float a, FluidMeasure b) => new FluidMeasure(a + b.Amount);
        public static FluidMeasure operator -(FluidMeasure a, FluidMeasure b) => new FluidMeasure(a._amount - b.Amount);
        public static FluidMeasure operator -(FluidMeasure a, float b) => new FluidMeasure(a._amount - b);
        public static FluidMeasure operator -(float a, FluidMeasure b) => new FluidMeasure(a - b.Amount);
    }
}
