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
            //Game.Do(new LoadMapDataCommand());
            //Game.Do(new GenerateCityCommand());
            Game.Do(new GetItemCommand("Clock"));
            Game.Do(new GetItemCommand("TestBook"));
            Game.Do(new StartNarrativeCommand(_narrative));
        }
    }
}