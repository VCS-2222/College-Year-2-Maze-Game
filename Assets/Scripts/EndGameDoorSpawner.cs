using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameDoorSpawner : MonoBehaviour
{
    [SerializeField] GameObject endGameDoor;
    [SerializeField] GameObject[] spawnPoints;

    private void Start()
    {
        int scrapInt = Random.Range(0, spawnPoints.Length);
        Instantiate(endGameDoor, spawnPoints[scrapInt].transform.position, spawnPoints[scrapInt].transform.rotation);
    }
}