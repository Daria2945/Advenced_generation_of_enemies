using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    private float _speed;
    private Target _target;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
        transform.LookAt(_target.transform.position);
    }

    public void SetTarget(Target target)
    {
        _target = target;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }
}