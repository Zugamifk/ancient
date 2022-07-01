using SpiritVessel.Commands;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SpiritVessel.ViewModel;
using SpiritVessel.Data;

namespace SpiritVessel.View
{
    public class LightningStrike : MonoBehaviour
    {
        static Collider2D[] _colliderBuffer = new Collider2D[16];
        static HashSet<Spirit> _chainTargets = new();
        private void OnTriggerEnter2D(Collider2D collision)
        {
            var spirit = collision.gameObject.GetComponent<Spirit>();
            if (enabled && spirit != null)
            {
                DoLightningHit(spirit);
            }
        }

        void DoLightningHit(Spirit spirit)
        {
            enabled = false;
            GetComponent<MapPositionable>().enabled = false;
            transform.position = spirit.transform.position;

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
                    break;
                }

                for (int j = 0; j < 100; j++)
                {
                    var target = _colliderBuffer[Random.Range(0, inRangeCount)];
                    spirit = target.gameObject.GetComponent<Spirit>();
                    if (spirit == null)
                    {
                        continue;
                    }

                    if (!_chainTargets.Contains(spirit))
                    {
                        break;
                    }
                }

                if (spirit == null || _chainTargets.Contains(spirit))
                {
                    break;
                }

                HitSpirit(spirit);

                ShowChain(origin, spirit.transform.position);

                origin = spirit.transform.position;
            }
        }

        void HitSpirit(Spirit spirit)
        {
            Game.Do(new DamageSpiritCommand(spirit.Id, 2));
            VfxService.Play("LightningHit", spirit.transform.position, spirit.transform.parent);
            _chainTargets.Add(spirit);
        }

        void ShowChain(Vector3 start, Vector3 end)
        {
            Debug.DrawLine(start, end);
            var prefabs = DataService.GetData<SkillPrefabs>();
            var linePrefab = prefabs.GetPrefab("LightningChain");
            var line = Instantiate(linePrefab, transform);

            line.transform.position = start;
            var dir = end - start;
            line.transform.rotation = Quaternion.AngleAxis(Mathf.Rad2Deg * Mathf.Atan2(dir.y, dir.x), Vector3.forward);
            line.transform.localScale = new Vector3(dir.magnitude, 1, 1);
        }
    }
}
