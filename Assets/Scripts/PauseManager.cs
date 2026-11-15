using System.Net.NetworkInformation;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    public static bool isPaused = false;

    public void PauseGame()
    {
        if (isPaused) return;

        isPaused = true;

        pausePanel.SetActive(true);

        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {

        isPaused = false;

        pausePanel.SetActive(false);

        Time.timeScale = 1f;
    }

    public void RestartLevel()
    {
        isPaused = false;

        GameManager.Instance.RestartCurrentLevel();
    }

    public void ReturnToMenu()
    {
        isPaused = false;

        GameManager.Instance.ReturnMenu();
    }
}
