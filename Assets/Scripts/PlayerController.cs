using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 40000.0f;
    private Rigidbody playerRb;
    private PhysicalLives physicalLives;
    private GameOverManager gameOverManager;
    private GameManager gameManager;

    public AudioSource collisionSound;

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

    // Moves the player based on wasd input
    void MovePlayer()
    {
        if (gameOverManager.gameOver == false)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            playerRb.AddForce(Vector3.forward * speed * verticalInput * Time.deltaTime);
            playerRb.AddForce(Vector3.right * speed * horizontalInput * Time.deltaTime);
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
                physicalLives.explosionParticle.Play();
                physicalLives.explosionParticle2.Play();
                physicalLives.explosionParticle3.Play();
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
}
