using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCityCommand : ICommand
{
    
    public void Execute(GameModel model)
    {
        var cityGenerator = Services.Get<CityGenerator>();
        cityGenerator.Generate(model.MapModel);
    }
}
