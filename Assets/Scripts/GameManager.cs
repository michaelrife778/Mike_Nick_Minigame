using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int health = 3;
    public int platformsReached;
   [SerializeField] private int platformGoal;
    public GameObject[] platforms;
    private Vector3 offset = new Vector3(13.8f, -0.8f, 0.80f);
    public bool isGameActive;
    public GameObject titleScreen;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject winScreenUI;
    [SerializeField] private TextMeshProUGUI livesText;


    private PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        livesText.text = "Lives: " + health;
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
            livesText.text = "Lives: " + health;
        }
    }

    private void CheckGameOver()
    {
        if (health == 0)
        {
            Time.timeScale = 0;
            gameOverUI.SetActive(true);
        }
        
    } 

    public void WinGame()
    {
        Debug.Log("You Win");
        Time.timeScale = 0;
        winScreenUI.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        health = 3;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }
    

}
