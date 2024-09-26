using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    private EnemyMover _mover;
    private Target _target;

    public event Action<Enemy> TargetApproached;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Target currentTarget = other.GetComponent<Target>();

        if (currentTarget == _target)
            TargetApproached?.Invoke(this);
    }

    public void SetTarget(Target target)
    {
        _target = target;
        _mover.SetTarget(_target);
    }
}