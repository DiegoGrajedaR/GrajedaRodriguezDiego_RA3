using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Vector2 speedMove;
    private Vector2 offset;
    private Material material;
    private Rigidbody2D playerRb;

    void Start() 
    {
        material = GetComponent<SpriteRenderer>().material;
        playerRb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        offset =  (playerRb.linearVelocity.x * 0.1f) * speedMove * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
    

}
