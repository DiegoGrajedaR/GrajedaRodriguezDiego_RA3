using UnityEngine;

public class EndSceneController : MonoBehaviour
{
    public void ReturnMenu() 
    {
        GameManager.Instance.ReturnMenu();
    }

    public void ExitGame()
    {
        GameManager.Instance.ExitGame();
    }
}
