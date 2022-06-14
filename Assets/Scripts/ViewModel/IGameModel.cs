using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameModel
{
    IIdentifiableLookup<IIdentifiable> AllIdentifiables { get; }
    ITimeModel Time { get; }
    IIdentifiableLookup<ICharacterModel> Characters { get; }
    IInventoryModel Inventory { get; }
    ICheatController Cheats { get; }
    TModel GetModel<TModel>();
}
