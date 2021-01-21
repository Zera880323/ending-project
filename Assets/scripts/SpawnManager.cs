using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalsPrefabs;
    public int animalIndex;
    private float spawnRangeX = 20.0f;
    private float spawnPosZ = 30.0f;
    private float startDalay = 2.0f;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", startDalay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            SpawnRandomAnimal();
        }
    }

    void SpawnRandomAnimal()
    {
        int animalIndex = Random.Range(0, animalsPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(20, 50), 3f, spawnPosZ);

        Instantiate(animalsPrefabs[animalIndex], spawnPos,
            animalsPrefabs[animalIndex].transform.rotation);
    }
}
