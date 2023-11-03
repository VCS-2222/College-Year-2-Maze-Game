using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitySpawner : MonoBehaviour
{
    [Header("Variables and Components")]
    [SerializeField] GameObject entityToBeSpawned;
    [SerializeField] float spawnAfterSeconds;
    [SerializeField] GameObject[] possibleSpawnPoints;

    private void Start()
    {
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        int scrapInt = Random.Range(0, possibleSpawnPoints.Length);
        yield return new WaitForSeconds(spawnAfterSeconds);

        Instantiate(entityToBeSpawned, possibleSpawnPoints[scrapInt].transform.position, possibleSpawnPoints[scrapInt].transform.rotation);
    }
}