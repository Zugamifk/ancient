using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

public class StopExaminingItemCommand : ICommand
{
    Guid _id;

    public StopExaminingItemCommand(Guid id)
    {
        _id = id;
    }

    public void Execute(GameModel model)
    {
        var examinable = model.AllIdentifiables.GetItem(_id) as IExaminable;
        if (examinable == null)
        {
            throw new InvalidOperationException($"Item {examinable.Key} ({_id}) is not an IExaminable!");
        }

        Debug.Log($"Stop examining {examinable.Key} ({examinable.Id})");

        examinable.IsExamining = false;
        model.CurrentExaminable = null;
    }
}
