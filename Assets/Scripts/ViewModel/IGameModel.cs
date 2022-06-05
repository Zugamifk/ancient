using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.ViewModels;

public interface IGameModel
{
    IIdentifiableLookup<IIdentifiable> AllIdentifiables { get; }
    IMapModel Map { get; }
    ITimeModel Time { get; }
    IIdentifiableLookup<ICharacterModel> Characters { get; }

    IInventoryModel Inventory { get; }
    ICheatController Cheats { get; }
    ITowerDefense TowerDefense { get; }
}
