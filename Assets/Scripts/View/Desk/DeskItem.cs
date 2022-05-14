using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskItem : MonoBehaviour, IView<IItemModel>
{
    public string Name;
    IItemModel _model;

    public void InitializeFromModel(IItemModel model)
    {
        _model = model;
    }
}
