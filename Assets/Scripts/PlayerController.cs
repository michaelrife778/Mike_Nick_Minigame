using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    // Serializing Fields makes them visible in the unity Inspector, but keeps them private.
   [SerializeField] private float rotationSpeed;
    [SerializeField] private float launchForce;
    private GameObject focalPoint;
    // Start is called before the first frame update
    void Start()
    {
        //Gets a reference to the player rigidbody
        playerRb = GetComponent<Rigidbody>();
        //Finds the FocalPoint in the scene and creates a reference
        focalPoint = GameObject.FindGameObjectWithTag("FocalPoint");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        // Sets the position of the focal point to the players position
        focalPoint.transform.position = transform.position;
        // Rotates the focal point
        focalPoint.transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);

        // Launches the player in the direction that the focal point is facing when they press spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(focalPoint.transform.forward * Time.deltaTime * launchForce, ForceMode.Impulse);
        }
    }
}
