using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestBodyHealth
{
    // A Test behaves as an ordinary method
    [Test]
    public void NewHumanBody_IsAlive()
    {
        // Use the Assert class to test conditions
        var body = Services.Get<BodyBuilder>().BuildHuman();
        var healthService = Services.Get<HealthDiagnosticService>();
        Assert.IsTrue(healthService.IsAlive(body));
    }
}
