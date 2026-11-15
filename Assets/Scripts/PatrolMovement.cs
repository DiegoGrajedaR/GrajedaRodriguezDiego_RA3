using UnityEngine;

public class PatrolMovement : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float speed = 3f;

    private Transform actualTarget;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        actualTarget = pointB;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, actualTarget.position, speed * Time.deltaTime);

        float distance = Vector2.Distance(transform.position, actualTarget.position);

        if (distance < 0.1f)
        {
            if (actualTarget == pointB)
            {
                actualTarget = pointA;
                if (spriteRenderer != null) spriteRenderer.flipX = false;
            }
            else
            {
                actualTarget = pointB;
                if (spriteRenderer != null) spriteRenderer.flipX = true;
            }
        }
    }
}
