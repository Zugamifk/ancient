using City.Model;
using City.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Model;

namespace City.Commands
{
    public class CreateCityModelCommand : CreateModelCommand<CityModel>
    {
        protected override void OnCreatedModel(GameModel game, CityModel model)
        {
            Game.Do(new LoadMapDataCommand(model.MapModel.Id));
            Game.Do(new GenerateCityCommand());
        }
    }
}
