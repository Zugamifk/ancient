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
        var item = model.Inventory.Items.GetItem(_id);
        if (item is not IExaminableModel examinable)
        {
            throw new InvalidOperationException($"Item {item.Key} ({_id}) is not a package!");
        }

        Debug.Log($"Examining {item.Key} ({item.Id})");

        examinable.IsExamining = true;
    }
}
