using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.View
{
    public class Spirit : MonoBehaviour
    {
        public bool Folow;
        public Guid Id => _identifiable.Id;

        Identifiable _identifiable;

        void Start()
        {
            _identifiable = GetComponent<Identifiable>();
        }

        private void Update()
        {
            if (Folow)
            {
                Debug.Log(transform.position);
            }
        }

        private void OnDestroy()
        {
            var splatter = DataService.GetData<VfxCollection>().GetItem("BloodSplatter");
            var inst = Instantiate(splatter);
            inst.transform.parent = transform.parent;
            inst.transform.position = transform.position;
            inst.SetLayerRecursively(LayerMask.NameToLayer("SpiritVessel"));
        }
    }
}
