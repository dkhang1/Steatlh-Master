using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        

        if (collision.gameObject.CompareTag("Player"))
        {
            
            Debug.Log("Hit Player");
            collision.gameObject.GetComponent<PlayerController>().TakeDamage(20);
            Destroy(gameObject);
        }
        
    }

    private void FixedUpdate()
    {
        Destroy(gameObject, 2f);
    }
}
