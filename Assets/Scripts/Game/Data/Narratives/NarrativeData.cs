using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeData : ScriptableObject
{
    public string Name;
    public string StartStep;
    public NarrativeStepData[] Steps;
}
