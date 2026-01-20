using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public AudioSource collisionSound;
    public AudioSource explosionSound;

    private float speed = 50000.0f;
    private Rigidbody playerRb;
    private PhysicalLives physicalLives;
    private GameOverManager gameOverManager;
    private GameManager gameManager;
    private float horizontalInput;
    private float verticalInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        collisionSound = GetComponent<AudioSource>();
        physicalLives = GetComponent<PhysicalLives>();
        gameOverManager = GetComponent<GameOverManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    // Moves the player based on A and D input
    void MovePlayer()
    {
        if (gameOverManager.gameOver == false)
        {
            playerRb.AddForce(Vector3.right * speed * horizontalInput * Time.deltaTime);
        }
    }

    public void OnMove(InputValue inputValue)
    {
        if (gameOverManager.gameOver == false)
        {
            horizontalInput = inputValue.Get<Vector2>().x;
            verticalInput = inputValue.Get<Vector2>().y;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collided with an enemy.");
            Destroy(collision.gameObject, 0.8f);
            collisionSound.Play();
            physicalLives.timesHit++;

            if (physicalLives.timesHit == 1)
            {
                physicalLives.smokeParticle.Play();
            }

            if (physicalLives.timesHit == 2)
            {
                physicalLives.smokeyParticle.Play();
            }

            if (physicalLives.timesHit == 3)
            {
                physicalLives.fireParticle.Play();
            }

            if (physicalLives.timesHit == 4)
            {
                gameOverManager.gameOver = true;
                gameManager.GameOver();
                collisionSound.Stop();
                physicalLives.explosionParticle.Play();
                physicalLives.explosionParticle2.Play();
                physicalLives.explosionParticle3.Play();
                explosionSound.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Powerup"))
        {
            Debug.Log("Player has trigger a power up.");
            Destroy(other.gameObject);

            if (physicalLives.timesHit == 1)
            {
                physicalLives.smokeParticle.Stop();
                physicalLives.timesHit--;
            }

            if (physicalLives.timesHit == 2)
            {
                physicalLives.smokeyParticle.Stop();
                physicalLives.timesHit--;
            } 

            if (physicalLives.timesHit == 3)
            {
                physicalLives.fireParticle.Stop();
                physicalLives.timesHit--;
            }
        }
    }

    /// <summary>
    /// Makes a blue line face in the direction where the player is facing and make a blue sphere
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        // Makes the color blue
        Gizmos.color = Color.blue;
        // Draws a line
        Gizmos.DrawLine(transform.position, transform.forward * 500f);
        // Draws a sphere
        Gizmos.DrawSphere(transform.position, 1f);
    }
}
