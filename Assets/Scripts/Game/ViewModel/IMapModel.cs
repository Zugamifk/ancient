using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMapModel
{
    public IReadOnlyList<IBuildingModel> Buildings { get; }
}
