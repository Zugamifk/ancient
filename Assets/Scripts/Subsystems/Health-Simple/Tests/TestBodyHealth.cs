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
            var builder = new BodyBuilder();
            var body = builder.BuildHuman();
            var healthService = new HealthDiagnosticService();
            Assert.IsTrue(healthService.IsAlive(body));
        }

        [Test]
        public void NewBody_CanBreath()
        {
            var builder = new BodyBuilder();
            var body = builder.BuildHuman();
            var healthService = new HealthDiagnosticService();
            Assert.IsTrue(healthService.CanBreath(body));
        }

        [Test]
        public void NewBody_InhaleRaisesOxygenLevels()
        {
            var builder = new BodyBuilder();
            var body = builder.BuildHuman();
            var operationService = new HealthOperationService();
            operationService.SetBloodOxygenLevel(body, 50);
            var functionService = new HealthFunctionService();
            functionService.Inhale(body);

            foreach (var part in functionService.GetConnected(body.Head.Blood))
            {
                Assert.IsTrue(part.OxygenLevel > 50);
            }
        }

        [Test]
        public void RemoveHead_IsNotAlive()
        {
            var builder = new BodyBuilder();
            var body = builder.BuildHuman();
            var operationService = new HealthOperationService();
            operationService.Remove(body, body.Head);

            var healthService = new HealthDiagnosticService();
            Assert.IsFalse(healthService.IsAlive(body));
        }

        [Test]
        public void RemoveHead_CantBreath()
        {
            var builder = new BodyBuilder();
            var body = builder.BuildHuman();
            var operationService = new HealthOperationService();
            operationService.Remove(body, body.Head);

            var healthService = new HealthDiagnosticService();
            Assert.IsFalse(healthService.CanBreath(body));
        }

        [Test]
        public void NewBody_CanWalk()
        {
            var builder = new BodyBuilder();
            var body = builder.BuildHuman();
            var healthService = new HealthDiagnosticService();
            Assert.IsTrue(healthService.CanWalk(body));
        }

        [Test]
        public void RemoveLeftLeg_CanNotWalk()
        {
            var builder = new BodyBuilder();
            var body = builder.BuildHuman();
            var operationService = new HealthOperationService();
            operationService.Remove(body, body.LeftLeg);

            var healthService = new HealthDiagnosticService();
            Assert.IsFalse(healthService.CanWalk(body));
        }

        [Test]
        public void RemoveRightLeg_CanNotWalk()
        {
            var builder = new BodyBuilder();
            var body = builder.BuildHuman();
            var operationService = new HealthOperationService();
            operationService.Remove(body, body.RightLeg);

            var healthService = new HealthDiagnosticService();
            Assert.IsFalse(healthService.CanWalk(body));
        }

        [Test]
        public void NewBody_CanSee()
        {
            var builder = new BodyBuilder();
            var body = builder.BuildHuman();
            var healthService = new HealthDiagnosticService();
            Assert.IsTrue(healthService.CanSee(body));
        }
    }
}
