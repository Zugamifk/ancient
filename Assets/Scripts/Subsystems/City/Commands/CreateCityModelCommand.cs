using City.Model;
using City.ViewModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace City.Commands
{
    public class CreateCityModelCommand : CreateModelCommand<CityModel>
    {
        new public void Execute(GameModel model)
        {
            base.Execute(model);
            Game.Do(new LoadMapDataCommand(model.GetModel<ICityModel>().Map.Id));
            Game.Do(new GenerateCityCommand());
        }
    }
}
