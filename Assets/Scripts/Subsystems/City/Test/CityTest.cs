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
            Game.Do(new CreateCityModelCommand());
            Game.Do(new GetItemCommand("Map"));
        }
    }
}