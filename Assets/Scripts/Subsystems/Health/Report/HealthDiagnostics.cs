using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Health
{
    public class HealthDiagnostics
    {
        public HealthReport GetFullHealthReport(IBody body)
        {
            var report = new HealthReport();
            DiagnoseCardiacArrest(body, report);
            return report;
        }

        void DiagnoseCardiacArrest(IBody body, HealthReport report)
        {
            if (body.Heart.IsBeating)
            {
                return;
            }
            
            var condition = new CardiacArrest();
            report.AddCondition(condition);
        }
    }
}
