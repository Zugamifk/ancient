using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.View
{
    public class Spirit : MonoBehaviour
    {
        public Guid Id => _identifiable.Id;

        Identifiable _identifiable;

        void Start()
        {
            _identifiable = GetComponent<Identifiable>();
        }
    }
}
