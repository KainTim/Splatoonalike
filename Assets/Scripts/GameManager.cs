using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private float _nextEnemySpawnTime;
    public float EnemySpawnDelay = 5;
    public List<GameObject> Enemies;
    public Collider EnemyBox;
    private void Start()
    {
        _nextEnemySpawnTime = Time.time;
    }

    private void FixedUpdate()
    {
        if (!(_nextEnemySpawnTime <= Time.time))
            return;
        _nextEnemySpawnTime = Time.time + EnemySpawnDelay;
        Instantiate(Enemies[Random.Range(0, Enemies.Count)],GetRandomPointInBounds(EnemyBox.bounds),Quaternion.identity);
    }
    private static Vector3 GetRandomPointInBounds(Bounds bounds)
    {
        float randomX = Random.Range(bounds.min.x, bounds.max.x);
        float randomY = Random.Range(bounds.min.y, bounds.max.y);
        float randomZ = Random.Range(bounds.min.z, bounds.max.z);

        return new Vector3(randomX, randomY, randomZ);
    }
}
