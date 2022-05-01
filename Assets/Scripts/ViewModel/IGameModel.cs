using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameModel
{
    IMapModel Map { get; }
    ITimeModel Time { get; }
    IEnumerable<ICharacterModel> Characters { get; }
    IInventoryModel Inventory { get; }
    ICheatController Cheats { get; }
}
