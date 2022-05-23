using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class HeadModel : IHasName
    {
        public string Name { get; }
        public HeadModel()
        {
            Name = "Head";
        }

        public HeadModel(string ownerName)
        {
            Name = $"{ownerName} Head";
        } 
    }
}
