using Fluids;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class Heart : IHasName
    {
        const string NAME = "Heart";
        public string Name => NAME;
        public BloodCirculation BloodCirculation { get; } = new(10);
        public int HeartRate { get; set; } = 80;
    }
}
