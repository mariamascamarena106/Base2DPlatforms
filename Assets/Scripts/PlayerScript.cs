
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerInput playerInput;

    [SerializeField] float jumpForce = 10.0f;
    [SerializeField] float movementForce = 5f;

    Vector2 movementInput;
    bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        Physics2D.queriesStartInColliders = false;
        isGrounded = false;
    }

    void Update()
    {

        movementInput = playerInput.actions["Move"].ReadValue<Vector2>();

 
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector2.right * movementInput.x * movementForce);

        //isGrounded con Raycast
        //RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
    }
}
