using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private int startLives = 3;
    [SerializeField] private string firstLvlScene = "Level1";
    [SerializeField] private string menuScene = "Menu";
    [SerializeField] private string gameOverScene = "GameOver";
    [SerializeField] private string victoryScene = "Victory";


    public int lives;
    public int score;
    public bool isPlayerDead = false;


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

    // TODO: Metode que desuscriu del event de Scenes
    private void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Instance = null;
        }
    }

    //TODO: Metode per simplement al carregar la escena el Player no estigui mort
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 1f;
        isPlayerDead = false;
    }

    //TODO: Metode al perdre una vida el Player o morir definitivament
    public void PlayerDied()
    {
        if (isPlayerDead)
            return;

        isPlayerDead = true;
        lives--;

        if (lives <= 0)
        {
            SceneManager.LoadScene(gameOverScene);
        }
        else
        {
            RestartCurrentLevel();
        }
    }

    //TODO: Començar nova partida
    public void StartNewGame() 
    {
        lives = startLives;
        score = 0;

        Time.timeScale = 1f;

        SceneManager.LoadScene(firstLvlScene);
    }

    //TODO: Reiniciar nivel actual
    public void RestartCurrentLevel() 
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //TODO: Tornar al menu
    public void ReturnMenu() 
    {
        Time.timeScale = 1f;
        isPlayerDead = false;

        SceneManager.LoadScene(menuScene);
    }

    //TODO: Completar el joc, superant els 4 nivells
    public void CompleteGame() 
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(victoryScene);
    }

    //TODO: Sortir del joc
    public void ExitGame() 
    {
        Debug.Log("Sortint del joc...");
        Application.Quit();
    }

    //TODO: Sumar puntuacio a la Score
    public void AddScore(int value) 
    {
        score += value;
    }
}
