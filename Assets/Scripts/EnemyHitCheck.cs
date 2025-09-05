using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class EnemyHitCheck : MonoBehaviour
{
    bool hitCheck = true;

    private BoxCollider boxCr;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        boxCr = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemiesHitCheck();
    }

    void EnemiesHitCheck()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
        }
    }
}
