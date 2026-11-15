using UnityEngine;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        PlayerHealth player = other.GetComponentInParent<PlayerHealth>();

        if (player == null) return;

        levelManager.CompleteLevel();
    }
}
