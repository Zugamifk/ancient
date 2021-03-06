using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Narrative;
using System;

public partial class GameModel : IGameModel
{
    public IdentifiableCollection<IIdentifiable> AllIdentifiables { get; } = new IdentifiableCollection<IIdentifiable>();
    public TimeModel TimeModel = new TimeModel();
    public IdentifiableCollection<MapModel> Maps { get; } = new();
    public IdentifiableCollection<CharacterModel> Characters = new IdentifiableCollection<CharacterModel>();
    public InventoryModel Inventory = new InventoryModel();
    public IExaminable CurrentExaminable;
    public Dictionary<Type, object> TypeToModel = new();

    public ICheatController Cheats;

    public TModel GetModel<TModel>()
        where TModel : IRegisteredModel
    {
        if (TypeToModel.TryGetValue(typeof(TModel), out object model)) {
            return (TModel)model;
        } else {
            return default;
        }
    }

    public TModel CreateModel<TModel>()
        where TModel : IRegisteredModel, new()
    {
        var result = new TModel();
        SetModel(result);
        if (result is IMapUser mapUser)
        {
            Maps.AddItem(mapUser.MapModel);
        }
        return result;
    }

    public void SetModel<TModel>(TModel model)
        where TModel : IRegisteredModel
    {
        TypeToModel[typeof(TModel)] = model;
        foreach (var i in typeof(TModel).GetInterfaces())
        {
            if (typeof(IRegisteredModel).IsAssignableFrom(i))
            {
                TypeToModel[i] = model;
            }
        }
    }

    #region IGameModel
    ITimeModel IGameModel.Time => TimeModel;
    IIdentifiableLookup<ICharacterModel> IGameModel.Characters => Characters;
    IIdentifiableLookup<IMapModel> IGameModel.Maps => Maps;
    IInventoryModel IGameModel.Inventory => Inventory;
    ICheatController IGameModel.Cheats => Cheats;

    IIdentifiableLookup<IIdentifiable> IGameModel.AllIdentifiables => AllIdentifiables;
    #endregion

}
