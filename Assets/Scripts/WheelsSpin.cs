using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class WheelsSpin : MonoBehaviour
{
    private float wheelSpeed = 800.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveWheels();
    }
    void MoveWheels()
    {
        transform.rotation *= Quaternion.Euler(wheelSpeed * Time.deltaTime, 0, 0);
    }
}
