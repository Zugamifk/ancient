using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskTest : MonoBehaviour
{
    void Start()
    {
        Game.Do(new GetItemCommand("Clock"));

        //Game.Do(new LoadMapDataCommand());
        //Game.Do(new GenerateCityCommand());
        Game.Do(new GetItemCommand("Map"));
    }
}
