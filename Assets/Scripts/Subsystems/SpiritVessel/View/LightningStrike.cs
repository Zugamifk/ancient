using SpiritVessel.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;

namespace SpiritVessel.View
{
    public class LightningStrike : MonoBehaviour
    {
        static Collider2D[] _colliderBuffer = new Collider2D[16];
        static HashSet<Spirit> _chainTargets = new();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var spirit = collision.gameObject.GetComponent<Spirit>();
            if (spirit != null)
            {
                DoLightningHit(spirit);
            }
        }

        void DoLightningHit(Spirit spirit)
        {
            var spiritVessel = Game.Model.GetModel<ISpiritVesselModel>();
            var lightning = spiritVessel.LightningSkill;
            _chainTargets.Clear();

            HitSpirit(spirit);

            if (lightning.Chains == 0)
            {
                return;
            }

            Vector2 origin = spirit.transform.position;
            for (int i = 0; i < lightning.Chains; i++)
            {
                var inRangeCount = Physics2D.OverlapCircleNonAlloc(origin, lightning.ChainRadius, _colliderBuffer);
                if (inRangeCount == 0)
                {
                    return;
                }

                for (int j = 0; j < 100; j++)
                {
                    var target = _colliderBuffer[Random.Range(0, inRangeCount)];
                    spirit = target.gameObject.GetComponent<Spirit>();
                    if (spirit == null)
                    {
                        return;
                    }

                    if (!_chainTargets.Contains(spirit))
                    {
                        break;
                    }
                }

                if (_chainTargets.Contains(spirit))
                {
                    return;
                }

                HitSpirit(spirit);

                Debug.DrawLine(origin, spirit.transform.position);

                origin = spirit.transform.position;
            }
        }

        void HitSpirit(Spirit spirit)
        {
            Game.Do(new DamageSpiritCommand(spirit.Id, 2));
            VfxService.Play("LightningHit", spirit.transform.position, spirit.transform.parent);
            _chainTargets.Add(spirit);
        }
    }
}
