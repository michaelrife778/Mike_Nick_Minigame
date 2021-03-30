using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int health = 3;
    public GameObject[] platforms;
    private Vector3 offset = new Vector3(13.8f, -0.8f, 0.80f);
    private GameObject player;
<<<<<<< Updated upstream
    public bool isGameActive;
    public GameObject titleScreen;


=======
    private PlayerController playerController;
>>>>>>> Stashed changes
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckGameOver();
    }

    // this method is called in the player controller script 
    public void SpawnPlatform(Collider platformTrigger)
    {
        int spawnIndex;

        spawnIndex = Random.Range(0, platforms.Length);
        // Spawns a random platform at the position of the platform trigger that the player collided with + an offset 
        Instantiate(platforms[spawnIndex], platformTrigger.gameObject.transform.position + offset, platforms[spawnIndex].transform.rotation);        
    }

<<<<<<< Updated upstream
    public void StartGame()
    {
        isGameActive = true;

        titleScreen.gameObject.SetActive(false);
    }

    public void GameOver()
=======
    private void CheckGameOver()
>>>>>>> Stashed changes
    {
        if (playerController.outOfBounds)
        {
            playerController.outOfBounds = false;
            if (health == 0)
            {
                Time.timeScale = 0;
                Debug.Log("Game Over");
            }
            else
            {
                player.transform.position = new Vector3(0, 0.538f, 0);
                health -= 1;
            }
            
        }
    }

    
    //Test comments
    /*
     * 
     * Test
     * 
     * 
     */

}
