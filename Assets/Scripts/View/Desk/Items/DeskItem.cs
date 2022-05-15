using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Identifiable))]
public class DeskItem : MonoBehaviour, IView<IItemModel>
{
    public string Name;

    public void InitializeFromModel(IItemModel model)
    {
        var identifiable = GetComponent<Identifiable>();
        identifiable.Id = model.Id;
    }
}
