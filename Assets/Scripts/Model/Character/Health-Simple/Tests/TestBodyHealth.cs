using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace HealthSimple
{
    public class TestBodyHealth
    {
        // A Test behaves as an ordinary method
        [Test]
        public void NewBody_IsAlive()
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
        public void NewBody_InhaleRaisesOxygenLevels()
        {
            var body = Services.Get<BodyBuilder>().BuildHuman();
            var operationService = Services.Get<HealthOperationService>();
            operationService.SetBloodOxygenLevel(body, 50);
            var functionService = Services.Get<HealthFunctionService>();
            functionService.Inhale(body);

            foreach (var part in functionService.GetConnected(body.Head.Blood))
            {
                Assert.IsTrue(part.OxygenLevel > 50);
            }
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

        [Test]
        public void NewBody_CanWalk()
        {
            var body = Services.Get<BodyBuilder>().BuildHuman();
            var healthService = Services.Get<HealthDiagnosticService>();
            Assert.IsTrue(healthService.CanWalk(body));
        }

        [Test]
        public void RemoveLeftLeg_CanNotWalk()
        {
            var body = Services.Get<BodyBuilder>().BuildHuman();
            var operationService = Services.Get<HealthOperationService>();
            operationService.Remove(body, body.LeftLeg);

            var healthService = Services.Get<HealthDiagnosticService>();
            Assert.IsFalse(healthService.CanWalk(body));
        }

        [Test]
        public void RemoveRightLeg_CanNotWalk()
        {
            var body = Services.Get<BodyBuilder>().BuildHuman();
            var operationService = Services.Get<HealthOperationService>();
            operationService.Remove(body, body.RightLeg);

            var healthService = Services.Get<HealthDiagnosticService>();
            Assert.IsFalse(healthService.CanWalk(body));
        }

        [Test]
        public void NewBody_CanSee()
        {
            var body = Services.Get<BodyBuilder>().BuildHuman();
            var healthService = Services.Get<HealthDiagnosticService>();
            Assert.IsTrue(healthService.CanSee(body));
        }
    }
}
