using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManorBuildingBehaviour : MonoBehaviour, IBuildingBehaviour
{
    [SerializeField]
    ClockView _clock;

    public string Name => "Manor";

    public void UpdateModel(IGameModel model)
    {
        _clock.UpdateClock(model.Time);
    }
}
