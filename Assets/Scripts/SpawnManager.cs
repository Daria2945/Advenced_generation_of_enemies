using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawners;
    [SerializeField] private float _delay = 2f;

    private Coroutine _coroutine;

    private void Start()
    {
        _coroutine = StartCoroutine(SpawnEnemies());
    }

    private void Spawn()
    {
        _spawners[Random.Range(0, _spawners.Length)].SpawnEnemy();
    }

    private IEnumerator SpawnEnemies()
    {
        var wait = new WaitForSecondsRealtime(_delay);

        while (true)
        {
            Spawn();

            yield return wait;
        }
    }
}