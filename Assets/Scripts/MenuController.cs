using UnityEngine;

public class MenuController : MonoBehaviour
{
    public void StartGame() 
    {
        GameManager.Instance.StartNewGame();
    }

    public void ExitGame() 
    {
        GameManager.Instance.ExitGame();
    }
}
