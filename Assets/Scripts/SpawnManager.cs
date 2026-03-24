using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject[] powerup;
    public GameObject[] cars;

    private PlayerController playerControllerScript;
    private GameOverManager gameOverManager;
    private float zEnemySpawn = 15.0f;
    private float zPowerupSpawn = 15.0f;
    private float xSpawnRange = 14.25f;
    private float itemYSpawn = 0.00f;
    private float enemyYSpawn = 0.5f;
    private float powerupSpawnTime = 5.0f;
    private float enemySpawnTime = 0.14f;
    private float startDelay = 0.0f;
    private float itemStartDelay = 3.5f;
    int maxEnemies = 20;
    int spawnEnemies = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverManager = GameObject.Find("Player").GetComponent<GameOverManager>();
        SpawnCar();
        if(maxEnemies > spawnEnemies)
        {
            InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
        }
        InvokeRepeating("SpawnPowerup", itemStartDelay, powerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnRandomEnemy()
    {
        if (gameOverManager.gameOver == false && maxEnemies > spawnEnemies)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            int randomIndex = Random.Range(0, enemies.Length);

            Vector3 spawnPos = new Vector3(randomX, enemyYSpawn, zEnemySpawn);

            Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
            spawnEnemies++;
        }
    }

    public void RespawnEnemy(GameObject enemy)
    {
        if (gameOverManager.gameOver == false)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);

            Vector3 spawnPos = new Vector3(randomX, enemyYSpawn, zEnemySpawn);
            enemy.transform.position = spawnPos;
            enemy.GetComponent<BoxCollider>().enabled = true;
            enemy.SetActive(true);
        }
    }


    void SpawnPowerup()
    {
        if (gameOverManager.gameOver == false)
        {
            float randomX = Random.Range(-xSpawnRange, xSpawnRange);
            int randomIndex = Random.Range(0, powerup.Length);

            Vector3 spawnPos = new Vector3(randomX, itemYSpawn, zPowerupSpawn);

            Instantiate(powerup[randomIndex], spawnPos, powerup[randomIndex].gameObject.transform.rotation);
        }
    }

    /// <summary>
    /// The selected car only be active
    /// </summary>
    void SpawnCar()
    {
        foreach (GameObject car in cars)
        {
            car.SetActive(false);
        }
        cars[ManuManager.carSelected].SetActive(true);
    }
}
