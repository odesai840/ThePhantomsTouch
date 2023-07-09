using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRandom : MonoBehaviour
{
    [SerializeField] private Transform spawnParent;
    [SerializeField] private float spawnCooldown = 2f;
    
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;

    private bool isSpawning = false;

    private void Update(){
        if(!isSpawning){
            isSpawning = true;
            StartCoroutine(SpawnRoutine());
        }
    }

    private IEnumerator SpawnRoutine(){
        Spawn();
        yield return new WaitForSeconds(spawnCooldown);
        isSpawning = false;
    }

    private void Spawn(){
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawn = Random.Range(0, spawnPoints.Length);
        
        Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawn].position, transform.rotation, spawnParent);
    }
}
