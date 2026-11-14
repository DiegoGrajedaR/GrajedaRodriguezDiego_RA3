using UnityEngine;

public class TrapOnContact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        PlayerHealth player = other.GetComponentInParent<PlayerHealth>();
    }
}
