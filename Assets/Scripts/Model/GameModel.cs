using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameModel : IGameModel
{
    public MapModel MapModel = new MapModel();
    public TimeModel TimeModel = new TimeModel();
    public Dictionary<string, CharacterModel> Characters = new Dictionary<string, CharacterModel>();
    public Dictionary<string, string> UniqueCharacterNameToId = new Dictionary<string, string>();
    public Dictionary<string, NarrativeModel> Narratives = new Dictionary<string, NarrativeModel>();
    public InventoryModel Desk = new InventoryModel();
    public TurretDefenseModel TurretDefenseModel = new TurretDefenseModel();

    public IEnumerable<MovementModel> MovementModels => Characters.Values.Select(c => c.Movement).Concat(TurretDefenseModel.Enemies.Select(e => e.Movement));

    public ICheatController Cheats;

    public string GetIdFromName(string name) => UniqueCharacterNameToId[name];
    public CharacterModel GetCharacterFromKey(string key)
    {
        if (!Characters.ContainsKey(key))
        {
            key = GetIdFromName(key);
        }

        return Characters[key];
    }

    #region IGameModel
    IMapModel IGameModel.Map => MapModel;
    ITimeModel IGameModel.Time => TimeModel;
    IEnumerable<ICharacterModel> IGameModel.Characters => Characters.Values.Cast<ICharacterModel>();
    IInventoryModel IGameModel.Inventory => Desk;
    ICheatController IGameModel.Cheats => Cheats;

    string IGameModel.GetIdFromName(string name) => UniqueCharacterNameToId[name];
    ICharacterModel IGameModel.GetCharacterFromKey(string key) {
        if (!Characters.ContainsKey(key))
        {
            key = GetIdFromName(key);
        }

        return Characters[key];
    }
    #endregion

}
