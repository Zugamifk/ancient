using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IModelUpdateable
{
    void UpdateFromModel(IGameModel model);
}
