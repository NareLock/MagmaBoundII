using System;
using UnityEngine;

public class MoedaSpawn : MonoBehaviour
{
    public GameObject moedaPrefab;
    public Transform[] spawnPoints;
    public int totalCoins = 10;

    private void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            Vector3 spawnPosition = spawnPoint.position + UnityEngine.Random.insideUnitSphere * 2;
            spawnPosition.z = 0;

            Instantiate(moedaPrefab, spawnPosition, Quaternion.identity);
        }
    }
}















