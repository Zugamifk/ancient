using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCityCommand : ICommand
{
    public void Execute(GameController controller)
    {
        controller.MapController.CityGenerator.Generate(
            controller.Model.MapModel, 
            controller.MapController.PathFinder);
    }
}
