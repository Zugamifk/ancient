using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealthCommand : ICommand
{
    public void Execute(GameModel model)
    {
        var character = model.Characters.GetItem(Name.TestAgent);
        var body = character.Health.Body;
        var healthService = Services.Get<HealthDiagnosticService>();
        Debug.Log("IsAlive: " + healthService.IsAlive(body));
    }
}
