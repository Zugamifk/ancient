using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Health
{
    public class HealthReport
    {
        List<IHealthCondition> _conditions = new();

        public void AddCondition(IHealthCondition condition)
        {
            _conditions.Add(condition);
        }
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var c in _conditions)
            {
                sb.AppendLine($"{c.Name} -- {c.Severity}");
                sb.AppendLine(c.Description);
                sb.AppendLine("-----------------------------------------------");
            }
            return sb.ToString();
        }
    }
}
