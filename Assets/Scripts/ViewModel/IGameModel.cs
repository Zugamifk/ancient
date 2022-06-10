using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefense.ViewModels;
using City.ViewModel;

public interface IGameModel
{
    IIdentifiableLookup<IIdentifiable> AllIdentifiables { get; }
    ICityModel City { get; }
    ITimeModel Time { get; }
    IIdentifiableLookup<ICharacterModel> Characters { get; }

    IInventoryModel Inventory { get; }
    ICheatController Cheats { get; }
    ITowerDefense TowerDefense { get; }
}
