using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskItem : MonoBehaviour, IView<IItemModel>
{
    public string Name;

    public void InitializeFromModel(IGameModel gameModel, IItemModel model)
    {
        throw new System.NotImplementedException();
    }
}
