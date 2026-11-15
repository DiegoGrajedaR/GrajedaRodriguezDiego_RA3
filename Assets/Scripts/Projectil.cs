using UnityEngine;

public class Projectil : MonoBehaviour
{
    public float speed = 4f;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerHealth player = other.GetComponentInParent<PlayerHealth>();

        if (player != null)
        {
            Destroy(gameObject);
        }
        else if (other.CompareTag("Ground")) 
        {
            Destroy(gameObject);
        }

    }
}
