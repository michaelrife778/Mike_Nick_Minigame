using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] platforms;
    private Vector3 offset = new Vector3(6.5f, -0.8f, 0.80f);
    // Start is called before the first frame update
    void Start()
    {
        
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

    
}
