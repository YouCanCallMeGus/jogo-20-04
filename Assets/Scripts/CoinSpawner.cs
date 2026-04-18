using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject CoinPrefab;

    public float minX, maxX;
    public float minY, maxY;

    public float spawnTime = 5f;
    private float timer;

    void Start()
    {
        
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);

        Vector2 spawnPos = new Vector2(randomX, randomY);

        Instantiate(CoinPrefab, spawnPos, Quaternion.identity);
    }
}
