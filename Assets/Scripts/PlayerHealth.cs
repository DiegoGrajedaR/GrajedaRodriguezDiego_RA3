using UnityEditor.Build.Content;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private bool isDead = false;

    public void Die() 
    {
        if (isDead) return;

        isDead = true;

        AudioManager.Instance.PlayHitPlayerSound();
        GameManager.Instance.PlayerDied();
    }
}
