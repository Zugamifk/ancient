using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameModel
{
    public IMapModel Map { get; }
    public ITimeModel Time { get; }
}
