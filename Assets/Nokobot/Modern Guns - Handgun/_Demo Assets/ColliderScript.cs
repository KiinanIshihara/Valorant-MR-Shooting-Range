using System.Threading;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

     public float delayTime = 0.1f; // Adjust this value based on your needs
    private bool canCollide = false;

    void Start()
    {
        // Enable collision after a short delay
        Invoke("EnableCollision", delayTime);
    }

    void EnableCollision()
    {
        canCollide = true;
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the bullet can collide
        if (canCollide)
        {
            // Check if the bullet collides with any GameObject
            if (collision.gameObject != null && collision.rigidbody != null && collision.collider != null)
            {
                // Handle the collision with the GameObject
                //Destroy(collision.gameObject);

                // Destroy the bullet as well
                Destroy(gameObject);
            } else {
                Destroy(gameObject);
            }
        }
    }
}