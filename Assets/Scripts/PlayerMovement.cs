using UnityEngine;
// 1. Add the Input System namespace at the very top of your script
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator anim;

    // 2. Add a variable to store the incoming movement direction
    private Vector2 moveInput;
    private float facingDirection = 1f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); // Ensure this is assigned
    }

    // 3. This method is automatically called by the Player Input component
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        // 4. Use moveInput.x and moveInput.y instead of Input.GetAxis
        float horizontal = moveInput.x;
        float vertical = moveInput.y;

        if (horizontal != 0)
        {
            spriteRenderer.flipX = horizontal < 0;
        }



        // Only update animator if anim is assigned to avoid errors
        if (anim != null)
        {
            anim.SetFloat("Horizontal", Mathf.Abs(horizontal));
            anim.SetFloat("Vertical", Mathf.Abs(vertical));
        }

        rb.linearVelocity = new Vector2(horizontal, vertical) * moveSpeed;
    }
}
