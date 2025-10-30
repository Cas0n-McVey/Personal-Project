using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class WheelsSpin : MonoBehaviour
{
    private float wheelSpeed = 800.0f;
    private GameOverManager gameOverManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverManager = GameObject.Find("Player").GetComponent<GameOverManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveWheels();
    }
    void MoveWheels()
    {
        if (gameOverManager.gameOver == false)
        {
            transform.rotation *= Quaternion.Euler(wheelSpeed * Time.deltaTime, 0, 0);
        }
    }
}
