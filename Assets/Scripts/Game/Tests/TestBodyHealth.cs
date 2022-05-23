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
        var body = Services.Get<BodyBuilder>().BuildHuman();
        var healthService = Services.Get<HealthDiagnosticService>();
        Assert.IsTrue(healthService.IsAlive(body));
    }

    [Test]
    public void NewBody_CanBreath()
    {
        var body = Services.Get<BodyBuilder>().BuildHuman();
        var healthService = Services.Get<HealthDiagnosticService>();
        Assert.IsTrue(healthService.CanBreath(body));
    }

    [Test]
    public void RemoveHead_IsNotAlive()
    {
        var body = Services.Get<BodyBuilder>().BuildHuman();
        var operationService = Services.Get<HealthOperationService>();
        operationService.Remove(body, body.Head);

        var healthService = Services.Get<HealthDiagnosticService>();
        Assert.IsFalse(healthService.IsAlive(body));
    }

    [Test]
    public void RemoveHead_CantBreath()
    {
        var body = Services.Get<BodyBuilder>().BuildHuman();
        var operationService = Services.Get<HealthOperationService>();
        operationService.Remove(body, body.Head);

        var healthService = Services.Get<HealthDiagnosticService>();
        Assert.IsFalse(healthService.CanBreath(body));
    }
}
