using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class AttackRadius : MonoBehaviour
{
    CircleCollider2D _collider;

    public event Action<Guid, bool> EnemyInRadius;

    private void Awake()
    {
        _collider = GetComponent<CircleCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var id = collision.gameObject.GetComponent<Identifiable>();
        EnemyInRadius?.Invoke(id.Id, true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var id = collision.gameObject.GetComponent<Identifiable>();
        EnemyInRadius?.Invoke(id.Id, false);
    }

    public void SetRadius(float radius)
    {
        _collider.radius = radius;
    }
}
