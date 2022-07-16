using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Health.Tests
{
    public class HealthDiagnosticsTests
    {
        [Test]
        public void Print_Report()
        {
            var diag = new HealthDiagnostics();
            var body = new HumanBody();

            body.Heart.IsBeating = false;
            
            var report = diag.GetFullHealthReport(body);
            Debug.Log(report.ToString());
        }
    }
}
