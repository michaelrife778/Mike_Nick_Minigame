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
    public bool isGameActive;
    public GameObject titleScreen;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // this method is called in the player controller script 
    public void SpawnPlatform(Collider platformTrigger)
    {
        int spawnIndex;

        spawnIndex = Random.Range(0, platforms.Length);
        // Spawns a random platform at the position of the platform trigger that the player collided with + an offset 
        Instantiate(platforms[spawnIndex], platformTrigger.gameObject.transform.position + offset, platforms[spawnIndex].transform.rotation);        
    }

    public void StartGame()
    {
        isGameActive = true;

        titleScreen.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        if (health <= 0)
        {
            Time.timeScale = 0;
        }
        else
        {
            player.transform.position = new Vector3(32.09f, 1.02f, 0);
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
