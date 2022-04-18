using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuildingBehaviour
{
    string Name { get; }

    void UpdateModel(IGameModel model);
}
