using City.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using City.Model;
using City.ViewModel;

namespace City.Test
{
    public class CityTest : MonoBehaviour
    {
        void Start()
        {
            Game.Do(new CreateModelCommand<CityModel>());
            Game.Do(new LoadMapDataCommand(Game.Model.GetModel<ICityModel>().Map.Id));
            Game.Do(new GenerateCityCommand());
            Game.Do(new GetItemCommand("Map"));
        }
    }
}