using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameModel : IGameModel
{
    public MapModel MapModel = new MapModel();
    public TimeModel TimeModel = new TimeModel();
    public Dictionary<string, CharacterModel> Characters = new Dictionary<string, CharacterModel>();
    public Dictionary<string, NarrativeModel> Narratives = new Dictionary<string, NarrativeModel>();
    public InventoryModel Desk = new InventoryModel();
    public BookModel WorkBook = new BookModel();

    public ICheatController Cheats;

    #region IGameModel
    IMapModel IGameModel.Map => MapModel;
    ITimeModel IGameModel.Time => TimeModel;
    IEnumerable<ICharacterModel> IGameModel.Characters => Characters.Values.Cast<ICharacterModel>();
    IInventoryModel IGameModel.Desk => Desk;
    IBookModel IGameModel.WorkBook => WorkBook;
    ICheatController IGameModel.Cheats => Cheats;
    #endregion

}
