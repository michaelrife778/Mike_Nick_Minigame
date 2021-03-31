using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int health = 3;
    public int platformsReached;
   [SerializeField] private int platformGoal;
    public GameObject[] platforms;
    private Vector3 offset = new Vector3(13.8f, -0.8f, 0.80f);
    private GameObject player;
    public bool isGameActive;
    public GameObject titleScreen;


    private PlayerController playerController;
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
        if (platformsReached < platformGoal)
        {
            int spawnIndex;

            spawnIndex = Random.Range(0, platforms.Length);
            // Spawns a random platform at the position of the platform trigger that the player collided with + an offset 

            Instantiate(platforms[spawnIndex], platformTrigger.gameObject.transform.position + offset, platforms[spawnIndex].transform.rotation);
        }
        else
        {
            WinGame();
        }
    }

    public void StartGame()
    {
        isGameActive = true;

        titleScreen.gameObject.SetActive(false);
    }


    public void DecreaseLives(int lives)
    {
        if (playerController.isOutOfBounds)
        {
            playerController.isOutOfBounds = false;
            health -= lives;
        }

        player.transform.position = new Vector3(0, 0.538f, 0);
        
    }

    private void CheckGameOver()
    {
        if (health == 0)
        {
            Time.timeScale = 0;
        }
        
    } 

    public void WinGame()
    {
        Debug.Log("You Win");
    }
    

}
