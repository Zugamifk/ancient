using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public readonly struct Percentage
{
    readonly float _value;
    readonly bool _allowNegative;
    readonly bool _allowAbove100;
    public Percentage(float value) : this(value, false, false) { }
    public Percentage(float value, bool allowNegative, bool allowAbove100)
    {
        if (!allowAbove100 && value > 100)
        {
            value = 100;
        }
        else if (!allowNegative && value < 0)
        {
            value = 0;
        }

        _value = value;
        _allowNegative = allowNegative;
        _allowAbove100 = allowAbove100;
    }

    public static Percentage operator -(Percentage a) => new Percentage(-a._value);
    public static Percentage operator +(Percentage a, Percentage b) => new Percentage(a._value + b._value);
    public static Percentage operator -(Percentage a, Percentage b) => new Percentage(a._value - b._value);

    public static implicit operator float(Percentage a) => a._value;
    public static implicit operator Percentage(float a) => new Percentage(a);

    public static float operator *(float a, Percentage b) => a * b._value;
    public static float operator *(Percentage a, float b) => a._value * b;
}
