using City.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using City.Model;
using Model;

namespace City.Commands
{
    public class GenerateCityCommand : ICommand
    {
        static CityGenerator _cityGenerator = new CityGenerator();
        public void Execute(GameModel model)
        {
            _cityGenerator.Generate(model.GetModel<CityModel>());
        }
    }
}