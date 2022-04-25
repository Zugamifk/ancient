using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdateable
{
    void UpdateFromModel(IGameModel model);
}