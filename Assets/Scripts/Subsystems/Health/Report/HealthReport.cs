using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Health
{
    public class HealthReport
    {
        Dictionary<Type, IHealthCondition> _conditions = new();

        public void AddCondition<TCondition>(TCondition condition)
            where TCondition : IHealthCondition
        {
            _conditions.Add(typeof(TCondition), condition);
        }

        public bool HasCondition<TCondition>() => _conditions.ContainsKey(typeof(TCondition));

        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var c in _conditions.Values)
            {
                sb.AppendLine($"{c.Name} -- {c.Severity}");
                sb.AppendLine(c.Description);
                sb.AppendLine("-----------------------------------------------");
            }
            return sb.ToString();
        }
    }
}
