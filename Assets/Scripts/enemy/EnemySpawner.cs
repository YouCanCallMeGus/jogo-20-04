using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject player;

    public float minX, maxX;
    public float minY, maxY;

    public float spawnTime;
    private float timer;
    private float spawnAccelerator;
    private float spawnThreshold;
    private float spawnAcceleratorThreshold;

    void Start()
    {
        spawnAccelerator = .05f;
        spawnAcceleratorThreshold = .5f;
        spawnThreshold = 5f;
        spawnTime = 2f;
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnTime)
        {
            if (spawnTime > spawnAcceleratorThreshold)
            {
                spawnTime -= spawnAccelerator;
            }
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        if (player == null)
        {
            return;
        }
        
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector2 spawnPos = new Vector2(randomX, randomY);
        while (Vector2.Distance(spawnPos, player.transform.position) < spawnThreshold)
        {
            randomX = Random.Range(minX, maxX);
            randomY = Random.Range(minY, maxY);
            spawnPos = new Vector2(randomX, randomY);
        }
       

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }
}