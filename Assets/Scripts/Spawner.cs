using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Container[] _containers;
    [SerializeField] private float _delay = 2f;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private void Spawn()
    {
        _containers[Random.Range(0, _containers.Length)].GetEnemy();
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