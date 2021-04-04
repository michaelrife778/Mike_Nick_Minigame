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

            sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            sphere.transform.position = gameObject.transform.position + offset;
            sphereRB = sphere.AddComponent(typeof(Rigidbody)) as Rigidbody;
            sphereRB.mass = 2;
        }
    }
    private void SumoPlatform()
    {
        if (gameObject.CompareTag("SumoPlatform") && sphere != null)
        {
            
            if ((sphere.transform.position.x - player.transform.position.x) <= 5.8)
            {
                float speed = 7;
                sphereRB.AddForce((player.transform.position - sphere.transform.position).normalized * speed);
            }

            if (sphere.gameObject.transform.position.y < -1.2)
            {
                Debug.Log("Sphere fell");
                Object.Destroy(sphere);
            }
        }
    }
}
