using UnityEngine;

public class LeftRightTurn : MonoBehaviour
{
    private Rigidbody wheelsRb;

    private float tiltAngle = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        wheelsRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        LeftRightWheelsTurn();
    }

    void LeftRightWheelsTurn()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(0, horizontalInput * tiltAngle * Time.deltaTime, 0);

        Vector3 cap = transform.eulerAngles;
        cap.y = Mathf.Clamp(cap.y, -50, 50);
        transform.eulerAngles = cap;
    }


}
