using UnityEngine;
using UnityEngine.InputSystem;
using System;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour, InputSystem_Actions.IGameplayPlayerActions
{
    private InputSystem_Actions inputActions;

    private Vector2 directionMove;
    public float speed = 5f;
    public bool isGravityInverted = false;

    //Raycast
    public float rayLength = 0.6f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private SpriteRenderer sp;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();

        // TODO: Crea el new inputActions
        // TODO: Fes que els Callbacks avisin aquest script
        inputActions = new InputSystem_Actions();
        inputActions.GameplayPlayer.SetCallbacks(this);
    }

    private void OnEnable()
    {
        // TODO: Activa (Enable) l'inputActions
        inputActions.Enable();
    }

    private void OnDisable()
    {
        // TODO: Desactiva (Disable) l'inputActions
        inputActions.Disable();
    }


    public void OnFlipGravity(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (IsGrounded())
        {
            rb.gravityScale *= -1;
            isGravityInverted = !isGravityInverted;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0.2f * Math.Sign(rb.gravityScale));
            sp.flipY = !sp.flipY;
        }
        else
        {
            return;
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        directionMove = context.ReadValue<Vector2>();
    }

    bool IsGrounded()
    {
        Vector2 rayDirection = isGravityInverted ? Vector2.up : Vector2.down;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, rayLength, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * rayLength, Color.red);
        return hit.collider != null;
    }

    void Update() 
    {
        rb.linearVelocity = new Vector2(directionMove.x * speed, rb.linearVelocity.y);

    }

}
