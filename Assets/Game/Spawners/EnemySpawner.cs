using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject[] enemyPrefabs;
    Collider spawnColl;

    void Start()
    {
        spawnColl = GetComponent<Collider>();
        GameController.Instance.onStartGame += OnStartGame;
    }
    void OnStartGame()
    {
        CancelInvoke("Spawn");
        InvokeRepeating("Spawn", 3, 3);
    }
    public void Spawn()
    {
        if (GameController.Instance.remeaninEnemyCount > 0)
        {
            GameController.Instance.remeaninEnemyCount--;
            Vector3 spawnPos = Utils.GetRandomPositionInsideCollider(spawnColl);
            Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], spawnPos, Quaternion.identity);
        }
    }

}
