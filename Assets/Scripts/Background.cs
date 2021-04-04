using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public GameObject player;
    private float playerYPosition;
    private Vector3 offset = new Vector3(0, 0, 10);
   


    // Start is called before the first frame update
    void Start()
    {
        
        
        //playerYPosition = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //private Vector3 backgroundYPosition = new Vector3(0, -playerYPosition, 10);

        //playerYPosition = player.transform.position.y;

        

        transform.position = player.transform.position + offset;

        
    }
}
