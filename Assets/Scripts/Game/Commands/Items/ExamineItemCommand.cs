using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExamineItemCommand : ICommand
{
    Guid _id;

    public ExamineItemCommand(Guid id)
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

        Debug.Log($"Examining {examinable.Key} ({examinable.Id})");

        examinable.IsExamining = true;
        model.CurrentExaminable = examinable;
    }
}
