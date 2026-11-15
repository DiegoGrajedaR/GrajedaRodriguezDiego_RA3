using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private string nextSceneName;

    [SerializeField] private bool isFinalLevel;

    private bool isTransitioning = false;

    public void CompleteLevel()
    {
        if (isTransitioning)
            return;

        if (isFinalLevel)
        {
            isTransitioning = true;
            GameManager.Instance.CompleteGame();

            return;
        }

        isTransitioning = true;

        SceneManager.LoadScene(nextSceneName);
    }
}
