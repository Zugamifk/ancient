using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameModel
{
    public IMapModel Map { get; }
    public ITimeModel Time { get; }
    public IEnumerable<IAgentModel> Agents { get; }
    public IDeskModel Desk { get; }
    public ICheatController Cheats { get; }
}
