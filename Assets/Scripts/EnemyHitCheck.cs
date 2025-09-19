using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EnemyHitCheck : MonoBehaviour
{
    private BoxCollider boxCr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCr = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy has collided with a player.");
            Destroy(boxCr);
        }
    }
}
