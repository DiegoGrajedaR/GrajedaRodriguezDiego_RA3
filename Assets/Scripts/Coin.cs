using UnityEngine;

public class Coin : MonoBehaviour
{
    private int value = 100;
    [SerializeField] private AudioClip audioClip;
    private SpriteRenderer coinRenderer;
    private bool isCollected = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            coinRenderer.enabled = false;

            //GameManager.Instance.AddScore(points);
            AudioManager.Instance.PlayCoinSound();
            Destroy(gameObject, audioClip.length);

        }
    }
    void Start()
    {
        coinRenderer = GetComponent<SpriteRenderer>();
    }

}
