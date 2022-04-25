using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameModel
{
    public IMapModel Map { get; }
    public ITimeModel Time { get; }
    public IEnumerable<ICharacterModel> Characters { get; }
    public IInventoryModel Desk { get; }
    public IBookModel WorkBook { get; }
    public ICheatController Cheats { get; }
}
