using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.ViewModel
{
    public interface ILevelUpModel
    {
        IReadOnlyList<string> SkillOptions { get; }
    }
}
