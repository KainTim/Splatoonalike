using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float _nextEnemySpawnTime;
    public float EnemySpawnDelay = 5;
    public List<GameObject> Enemies;
    public Collider EnemyBox;
    public int MaxConcurrentEnemyCount = 5;
    private void Start()
    {
        _nextEnemySpawnTime = Time.time;
    }

    private void FixedUpdate()
    {
        if (!(_nextEnemySpawnTime <= Time.time))
            return;
        if (transform.childCount <= MaxConcurrentEnemyCount) 
            return;
        _nextEnemySpawnTime = Time.time + EnemySpawnDelay;
        var enemyInstance=Instantiate(Enemies[Random.Range(0, Enemies.Count)],GetRandomPointInBounds(EnemyBox.bounds),Quaternion.identity);
        enemyInstance.transform.SetParent(transform);
    }
    private static Vector3 GetRandomPointInBounds(Bounds bounds)
    {
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);

        return new Vector3(randomX, randomY, randomZ);
    }
}
