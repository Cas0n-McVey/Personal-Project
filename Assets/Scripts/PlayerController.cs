using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public AudioSource collisionSound;
    public AudioSource explosionSound;
    public GameManager gameManager;
    public SpawnManager spawnManager;
    public float speed = 50000.0f;

    private float iFramesDuration = 4.8f;
    private float horizontalInput;
    private float duration = 3f;
    private Rigidbody playerRb;
    private BoxCollider boxCr;
    private PhysicalLives physicalLives;
    private GameOverManager gameOverManager;
    private GameObject lastHitEnemy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCr = GetComponent<BoxCollider>();
        playerRb = GetComponent<Rigidbody>();
        collisionSound = GetComponent<AudioSource>();
        physicalLives = GetComponent<PhysicalLives>();
        gameOverManager = GetComponent<GameOverManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        physicalLives.pointLight.enabled = false;
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

    // Controlls for mobile players
    public void LeftButton()
    {
        Debug.Log("Left button works");
    }

    // Controlls for mobile players
    public void RightButton()
    {
        Debug.Log("Right button works");
    }

    /// <summary>
    /// To move in the new input system
    /// </summary>
    /// <param name="inputValue"></param>
    public void OnMove(InputValue inputValue)
    {
        // to stop the player from moving whenever a gameover happens
        if (gameOverManager.gameOver == false)
        {
            horizontalInput = inputValue.Get<Vector2>().x;
        }
    }

    /// <summary>
    /// For the Canvas Input script
    /// </summary>
    /// <param name="newMoveDir"></param>
    public void MoveInput(Vector2 newMoveDir)
    {
        horizontalInput = newMoveDir.x;
    }

    /// <summary>
    /// My physical life system and you can only tell how the car looks
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collided with an enemy.");
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            enemyRb.linearVelocity = Vector3.zero;
            enemyRb.angularVelocity = Vector3.zero;
            collision.gameObject.SetActive(false);
            lastHitEnemy = collision.gameObject;
            Invoke(nameof(Respawn), 0.14f);

            collisionSound.Play();
            physicalLives.timesHit++;

            if (physicalLives.timesHit == 1)
            {
                physicalLives.smokeParticle.Play();
                physicalLives.headLight.enabled = false;
            }

            if (physicalLives.timesHit == 2)
            {
                physicalLives.smokeyParticle.Play();
                physicalLives.headLight2.enabled = false;
            }

            if (physicalLives.timesHit == 3)
            {
                physicalLives.fireParticle.Play();
            }

            // At timesHit 4 is a game over
            if (physicalLives.timesHit == 4)
            {
                gameOverManager.gameOver = true;
                gameManager.GameOver();
                collisionSound.Stop();
                explosionSound.Play();
                physicalLives.explosionParticle.Play();
                physicalLives.explosionParticle2.Play();
                physicalLives.explosionParticle3.Play();
            }
        }
    }

    private void Respawn()
    {
        spawnManager.RespawnEnemy(lastHitEnemy);
    }

    /// <summary>
    /// Powerup give you a life back if you got hit by an enemy
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Powerup"))
        {
            physicalLives.healing.Play();
            StartCoroutine(ToggleLightForTime());
            Debug.Log("Player has trigger a power up.");
            Destroy(other.gameObject);
            spawnManager.spawnPowerUp--;

            if (physicalLives.timesHit == 1)
            {
                physicalLives.smokeParticle.Stop();
                physicalLives.timesHit--;
            }

            if (physicalLives.timesHit == 2)
            {
                physicalLives.smokeyParticle.Stop();
                physicalLives.timesHit--;
                physicalLives.headLight.enabled = true;
            } 

            // Doesn't revive you when your hit times is at 4
            if (physicalLives.timesHit == 3)
            {
                physicalLives.fireParticle.Stop();
                physicalLives.timesHit--;
                physicalLives.headLight2.enabled = true;
            }

            if (physicalLives.timesHit >= 4)
            {
                physicalLives.secret.Play();
            }
        }

        IEnumerator ToggleLightForTime()
        {
            physicalLives.pointLight.enabled = true;
            yield return new WaitForSeconds(duration);
            physicalLives.pointLight.enabled = false;
        }

        // Powerful gives you I-frames at amount of time given
        if(other.gameObject.CompareTag("Powerful"))
        {
            Debug.Log("Player has I-frames");
            Destroy(other.gameObject);

            if (physicalLives.timesHit < 4)
            {
                StartCoroutine(DisableAndReEnableCollider());
            }
        }

        // Enable and disable the box collider at amount of time given
        IEnumerator DisableAndReEnableCollider()
        {
            if (boxCr != null)
            {
                physicalLives.iFrames.Play();
                boxCr.enabled = false; // Disable the collider
                Debug.Log("Collider Disabled");

                yield return new WaitForSeconds(iFramesDuration); // Wait for the specified time

                boxCr.enabled = true; // Re-enable the collider
                Debug.Log("Collider Re-enabled");
                physicalLives.iFrames.Stop();
                physicalLives.removeIFrames.Play();
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
