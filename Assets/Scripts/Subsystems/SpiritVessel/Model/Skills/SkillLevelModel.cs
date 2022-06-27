using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.Model
{
    public class SkillLevelModel : IIdentifiable
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
