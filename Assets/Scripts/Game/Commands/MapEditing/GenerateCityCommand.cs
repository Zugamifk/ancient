using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCityCommand : ICommand
{
    static CityGenerator _cityGenerator = new CityGenerator();
    public void Execute(GameModel model)
    {
        _cityGenerator.Generate(model.MapModel);
    }
}
