using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        // General collision debug message
        Debug.Log("Collision detected with: " + collision.gameObject.name);

        if (collision.collider.name == "Target")
        {
            Debug.Log("Hit an obstacle!!");
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Nebin"))
        {
            Debug.Log("Hit Nebin!!");
            Destroy(gameObject);
        }
        if (collision.collider.tag == "Rigid")
        {
            Debug.Log("Hit a rigidbody!!");
            Destroy(gameObject);
        }
    }
}
