using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject powerup;

    private PlayerController playerControllerScript;
    private GameOverManager gameOverManager;
    private float zEnemySpawn = 15.0f;
    private float zPowerupSpawn = 15.0f;
    private float xSpawnRange = 14.25f;
    private float ySpawn = 0.75f;
    private float powerupSpawnTime = 5.0f;
    private float enemySpawnTime = 0.15f;
    private float startDelay = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverManager = GameObject.Find("Player").GetComponent<GameOverManager>();
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnPowerup", startDelay, powerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomEnemy()
    {
        if (gameOverManager.gameOver == false)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            int randomIndex = Random.Range(0, enemies.Length);

            Vector3 spawnPos = new Vector3(randomX, ySpawn, zEnemySpawn);

            Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
        }
    }

    void SpawnPowerup()
    {
        if (gameOverManager.gameOver == false)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);

            Vector3 spawnPos = new Vector3(randomX, ySpawn, zPowerupSpawn);

            Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
        }
    }
}
