using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private SpawnPoint[] _spawnPoints;
    [SerializeField] private float _delay = 2f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private void Spawn()
    {
        _spawnPoints[Random.Range(0, _spawnPoints.Length)].SpawnEnemy();
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