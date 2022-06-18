using Narrative.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Narrative.View
{
    public class SimpleNarrativeTest : MonoBehaviour
    {
        [SerializeField]
        string _narrative;

        void Start()
        {
            Game.Do(new StartNarrativeCommand(_narrative));
        }
    }
}