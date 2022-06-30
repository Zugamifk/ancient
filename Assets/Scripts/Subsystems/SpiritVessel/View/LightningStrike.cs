using SpiritVessel.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpiritVessel.View
{
    public class LightningStrike : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var spirit = collision.gameObject.GetComponent<Spirit>();
            if (spirit != null)
            {
                Game.Do(new DamageSpiritCommand(spirit.Id, 2));
                VfxService.Play("LightningHit", spirit.transform.position, spirit.transform.parent);
            }
        }
    }
}
