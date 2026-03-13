using System.Runtime.CompilerServices;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 5.0f;

    private float zDestroy = -16.0f;
    private Rigidbody objectRb;
    private GameOverManager gameOverManager;
    private SpawnManager spawnManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
        gameOverManager = GameObject.Find("Player").GetComponent<GameOverManager>();
        spawnManager = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        // Makes it move down
        if (gameOverManager.gameOver == false)
        {
            objectRb.AddForce(Vector3.forward * -speed * Time.deltaTime);
        }

        // Destroy game object at a specific Z axis
        if (transform.position.z < zDestroy && gameOverManager.gameOver == false)
        {
            gameObject.SetActive(false);
            objectRb.linearVelocity = Vector3.zero;
            objectRb.angularVelocity = Vector3.zero;
            Invoke(nameof(Respawn), 1f);
        }
    }

    private void Respawn()
    {
        spawnManager.RespawnEnemy(gameObject);
    }
}