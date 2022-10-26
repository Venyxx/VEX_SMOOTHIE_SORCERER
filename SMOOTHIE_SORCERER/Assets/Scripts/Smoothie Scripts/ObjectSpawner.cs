using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject[] Fruit;
    public Transform SpawnPoint;
    public float IntervalBetweenSpawn;

    private float spawnBetweenTime;
    // Update is called once per frame
    void FixedUpdate()
    {
        if(spawnBetweenTime <= 0)
        {
            int rand = Random.Range(0, Fruit.Length);
            Instantiate(Fruit[rand], SpawnPoint.position, Quaternion.identity);
            spawnBetweenTime = IntervalBetweenSpawn;
        }
        else
        {
            spawnBetweenTime -= Time.deltaTime;

        }
    }
}