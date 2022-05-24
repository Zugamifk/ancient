using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Health
{
    public class Nerve : IHasName
    {
        public string Name { get; }
        HashSet<Nerve> _connected = new();
        public IEnumerable<Nerve> Connected => _connected;

        public Nerve()
        {
            Name = "Nerve";
        }

        public Nerve(string ownerName)
        {
            Name = $"{ownerName} Nerve";
        }

        public bool IsConnectedTo(Nerve other)
        {
            return _connected.Contains(other);
        }

        public void ConnectTo(Nerve other)
        {
            _connected.Add(other);
        }
    }
}
