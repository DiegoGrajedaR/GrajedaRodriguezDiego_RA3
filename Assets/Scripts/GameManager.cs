using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int startLives = 3;
    [SerializeField] private string gameOverScene = "GameOver";

    public int lives;
    public int score;
    public bool isDead = false;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        lives = startLives;
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //Metode que desuscriu del event de Scenes
    private void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Instance = null;
        }
    }

    //Metode per simplement al carregar la escena el Player no estigui mort
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isDead = false;
    }

    public void PlayerDied()
    {
        if (isDead)
            return;

        isDead = true;
        lives--;

        if (lives <= 0)
        {
            SceneManager.LoadScene(gameOverScene);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }


    public void AddScore(int value) 
    {
        score += value;
    }
}
