using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
   private GameObject sphere;
   private Rigidbody sphereRB;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        SumoPlatformSetUp();
    }

    // Update is called once per frame
    void Update()
    {
        SpinPlatform();
        SumoPlatform();
    }

    // spins the platform for the spin platforms
    private void SpinPlatform()
    {
        if (gameObject.CompareTag("SpinPlatform"))
        {
            float rotationSpeed = 15f;
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
        }
    }

    private void SumoPlatformSetUp()
    {
        if (gameObject.CompareTag("SumoPlatform"))
        {
            Vector3 offset = new Vector3(0, 0.8f, 0);
            // creates a new sphere game object
            sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            // sets the spheres position to the position of the platform + an offset
            sphere.transform.position = gameObject.transform.position + offset;
            // adds a rigid body to the sphere
            sphereRB = sphere.AddComponent(typeof(Rigidbody)) as Rigidbody;
            // sets the mass of the sphere
            sphereRB.mass = 2;
        }
    }
    private void SumoPlatform()
    {
        if (gameObject.CompareTag("SumoPlatform") && sphere != null)
        {
            // checks to see if the player is close enough to the sphere
            if ((sphere.transform.position.x - player.transform.position.x) <= 5.8)
            {
                float speed = 7;
                // makes the sphere chase the player off the platform
                sphereRB.AddForce((player.transform.position - sphere.transform.position).normalized * speed);
            }

            // Destroys the sphere when it falls
            if (sphere.gameObject.transform.position.y < -1.2)
            {
                Debug.Log("Sphere fell");
                // using object instead of normal Destroy so that is destroys the instance.
                Object.Destroy(sphere);
            }
        }
    }
}
