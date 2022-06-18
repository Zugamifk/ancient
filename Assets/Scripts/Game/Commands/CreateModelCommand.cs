using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateModelCommand<TModel> : ICommand
    where TModel : IRegisteredModel, new()
{
    public void Execute(GameModel model)
    {
        model.CreateModel<TModel>();
    }
}
