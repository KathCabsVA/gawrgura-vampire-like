using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{


    public GameObject toSpawn;
    public float spawnTimer;
    public float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", spawnTimer, spawnTimer);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnEnemy()
    {
        Instantiate(toSpawn, transform.position, Quaternion.identity);
    }
}
