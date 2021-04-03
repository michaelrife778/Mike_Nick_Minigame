﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    // Serializing Fields makes them visible in the unity Inspector, but keeps them private.
   [SerializeField] private float rotationSpeed;
    [SerializeField] private float launchForce;
    private GameObject focalPoint;
    private GameManager gameManager;
    public bool isOutOfBounds;
    private bool canJump = true;
    private AudioSource playerAudio;
    public AudioClip jumpSound;


    // Start is called before the first frame update
    void Start()
    {
        //Gets a reference to the player rigidbody
        playerRb = GetComponent<Rigidbody>();
        //Finds the FocalPoint in the scene and creates a reference
        focalPoint = GameObject.FindGameObjectWithTag("FocalPoint");

        playerAudio = GetComponent<AudioSource>();

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        OutOfBounds();
    }

    private void Movement()
    {
        // Sets the position of the focal point to the players position
        focalPoint.transform.position = transform.position;
        // Rotates the focal point
        focalPoint.transform.Rotate(Vector3.right * Time.deltaTime * rotationSpeed);

        // Launches the player in the direction that the focal point is facing when they press spacebar
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            StartCoroutine(JumpDelay());
            playerRb.AddForce(focalPoint.transform.forward * launchForce, ForceMode.Impulse);
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform Trigger"))
        {
            gameManager.platformsReached += 1;
            other.gameObject.SetActive(false);
            gameManager.SpawnPlatform(other);   
        }
    }

    private void OutOfBounds()
    {
        if (transform.position.y < -5)
        {
            isOutOfBounds = true;
            gameManager.DecreaseLives(1);
           transform.position = new Vector3(0, 0.538f, 0);
        }
    }

    IEnumerator JumpDelay()
    {
        canJump = false;
        yield return new WaitForSeconds(1);
        canJump = true;
    }

    
}
