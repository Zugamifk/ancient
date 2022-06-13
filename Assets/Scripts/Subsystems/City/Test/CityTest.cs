using City.Commands;
using Map.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using City.Model;

namespace City.View
{
    public class CityTest : MonoBehaviour
    {
        void Start()
        {
            Game.Do(new LoadMapDataCommand(Game.MutableModel.GetModel<CityModel>().MapModel));
            Game.Do(new GenerateCityCommand());
        }
    }
}