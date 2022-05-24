using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TowerDefense.Models;
using TowerDefense.ViewModels;

public class GameModel : IGameModel
{
    public MapModel MapModel = new MapModel();
    public TimeModel TimeModel = new TimeModel();
    public IdentifiableCollection<CharacterModel> Characters = new IdentifiableCollection<CharacterModel>();
    public Dictionary<string, NarrativeModel> Narratives = new Dictionary<string, NarrativeModel>();
    public InventoryModel Inventory = new InventoryModel();
    public TowerDefenseGame TowerDefense = new TowerDefenseGame();

    public IEnumerable<MovementModel> MovementModels => Characters.AllItems.Select(c => c.Movement);

    public ICheatController Cheats;

    #region IGameModel
    IMapModel IGameModel.Map => MapModel;
    ITimeModel IGameModel.Time => TimeModel;
    IIdentifiableLookup<ICharacterModel> IGameModel.Characters => Characters;
    IInventoryModel IGameModel.Inventory => Inventory;
    ICheatController IGameModel.Cheats => Cheats;
    ITowerDefense IGameModel.TowerDefense => TowerDefense;
    #endregion

}
