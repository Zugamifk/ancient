using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public interface IBloodCirculator
    {
        BloodCirculation BloodCirculation { get; }
    }
}
