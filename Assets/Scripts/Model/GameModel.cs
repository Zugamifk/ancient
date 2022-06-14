using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Narrative;
using System;

public class GameModel : IGameModel
{
    public IdentifiableCollection<IIdentifiable> AllIdentifiables { get; } = new IdentifiableCollection<IIdentifiable>();
    public TimeModel TimeModel = new TimeModel();
    public IdentifiableCollection<CharacterModel> Characters = new IdentifiableCollection<CharacterModel>();
    public Dictionary<string, NarrativeModel> Narratives = new Dictionary<string, NarrativeModel>();
    public InventoryModel Inventory = new InventoryModel();
    public IExaminable CurrentExaminable;
    public Dictionary<Type, object> TypeToModel = new();

    public ICheatController Cheats;

    public TModel GetModel<TModel>()
    {
        if(!typeof(IRegisteredModel).IsAssignableFrom(typeof(TModel)))
        {
            throw new ArgumentException($"TModel {typeof(TModel)} does not inherit from IModel!");
        }

        return (TModel)TypeToModel[typeof(TModel)];
    }

    public void CreateModel<TModel>()
        where TModel : IRegisteredModel, new()
    {
        SetModel<TModel>(new());
    }

    public void SetModel<TModel>(TModel model)
        where TModel : IRegisteredModel
    {
        TypeToModel[typeof(TModel)] = model;
        TypeToModel[model.GetType()] = model;
    }

    #region IGameModel
    ITimeModel IGameModel.Time => TimeModel;
    IIdentifiableLookup<ICharacterModel> IGameModel.Characters => Characters;
    IInventoryModel IGameModel.Inventory => Inventory;
    ICheatController IGameModel.Cheats => Cheats;

    IIdentifiableLookup<IIdentifiable> IGameModel.AllIdentifiables => AllIdentifiables;
    #endregion

}
