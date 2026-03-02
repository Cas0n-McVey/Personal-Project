using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;

public class RightMove : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isPressed = false;
    public GameObject Player;
    public Rigidbody playerRb;

    private float Force = 50000.0f;
    private PlayerController playerController;

    // Update is called once per frame
    void Update()
    {
        // Mobile button for going right
        if (isPressed)
        {
            playerRb.AddForce(Vector3.right * Force * Time.deltaTime);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
