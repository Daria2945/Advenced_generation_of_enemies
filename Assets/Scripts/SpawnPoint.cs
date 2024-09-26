using UnityEngine;
using UnityEngine.Pool;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Target _target;
    [SerializeField] private Enemy _enemyPrefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private int _poolCapacity = 5;
    [SerializeField] private int _poolMaxSize = 10;

    private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        CreatePool();
    }

    public void SpawnEnemy()
    {
        Enemy enemy = _pool.Get();
        enemy.SetTarget(_target);
        enemy.TargetApproached += ReturnToPool;
    }

    private void CreatePool()
    {
        _pool = new ObjectPool<Enemy>(
            createFunc: () => Instantiate(_enemyPrefab),
            actionOnGet: (enemy) => ConfigureEnemy(enemy),
            actionOnRelease: (enemy) => enemy.gameObject.SetActive(false),
            actionOnDestroy: (enemy) => Destroy(enemy.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
            );
    }

    private void ConfigureEnemy(Enemy enemy)
    {
        enemy.transform.position = _spawnPoint.position;
        enemy.gameObject.SetActive(true);
    }

    private void ReturnToPool(Enemy enemy)
    {
        _pool.Release(enemy);
        enemy.TargetApproached -= ReturnToPool;
    }
}