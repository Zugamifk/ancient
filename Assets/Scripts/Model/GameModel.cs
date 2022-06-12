using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TowerDefense.Models;
using TowerDefense.ViewModels;
using City.Model;
using City.ViewModel;
using Narrative;

public class GameModel : IGameModel
{
    public IdentifiableCollection<IIdentifiable> AllIdentifiables { get; } = new IdentifiableCollection<IIdentifiable>();
    public CityModel CityModel { get; } = new CityModel();
    public TimeModel TimeModel = new TimeModel();
    public IdentifiableCollection<CharacterModel> Characters = new IdentifiableCollection<CharacterModel>();
    public Dictionary<string, NarrativeModel> Narratives = new Dictionary<string, NarrativeModel>();
    public InventoryModel Inventory = new InventoryModel();
    public TowerDefenseGame TowerDefense = new TowerDefenseGame();
    public IExaminable CurrentExaminable;
    public IEnumerable<MovementModel> MovementModels => Characters.AllItems.Select(c => c.Movement);

    public ICheatController Cheats;

    #region IGameModel
    ICityModel IGameModel.City => CityModel;
    ITimeModel IGameModel.Time => TimeModel;
    IIdentifiableLookup<ICharacterModel> IGameModel.Characters => Characters;
    IInventoryModel IGameModel.Inventory => Inventory;
    ICheatController IGameModel.Cheats => Cheats;
    ITowerDefense IGameModel.TowerDefense => TowerDefense;

    IIdentifiableLookup<IIdentifiable> IGameModel.AllIdentifiables => AllIdentifiables;
    #endregion

}
