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
        if (transform.position.z < zDestroy)
        {
            objectRb.linearVelocity = Vector3.zero;
            gameObject.SetActive(false);
            
        }
    }
}