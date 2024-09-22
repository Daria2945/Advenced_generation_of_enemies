using System;
using UnityEngine;

[RequireComponent(typeof(EnemyMover), typeof(Rigidbody))]
public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private EnemyMover _mover;

    public event Action<Enemy> TargetApproached;

    private void Awake()
    {
        _mover = GetComponent<EnemyMover>();
        _mover.SetSpeed(_speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Target>())
            TargetApproached?.Invoke(this);
    }

    public void SetTarget(Target target)
    {
        _mover.SetTarget(target);
    }
}