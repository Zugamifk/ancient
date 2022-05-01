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
    public TurretDefenseModel TurretDefenseModel = new TurretDefenseModel();

    public IEnumerable<MovementModel> MovementModels => Characters.Values.Select(c => c.Movement).Concat(TurretDefenseModel.Enemies.Select(e => e.Movement));

    public ICheatController Cheats;

    #region IGameModel
    IMapModel IGameModel.Map => MapModel;
    ITimeModel IGameModel.Time => TimeModel;
    IEnumerable<ICharacterModel> IGameModel.Characters => Characters.Values.Cast<ICharacterModel>();
    IInventoryModel IGameModel.Inventory => Desk;
    ICheatController IGameModel.Cheats => Cheats;
    #endregion

}
