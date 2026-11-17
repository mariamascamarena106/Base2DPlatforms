
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    Rigidbody2D rb;
    PlayerInput playerInput;
    SpriteRenderer sr;

    [SerializeField] float jumpForce = 10.0f;
    [SerializeField] float movementForce = 5f;

    Vector2 movementInput;
    bool isGrounded = false;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        //no colisionar con mi propio collider
        Physics2D.queriesStartInColliders = false;

    }

    void Update()
    {

        movementInput = playerInput.actions["Move"].ReadValue<Vector2>();

        /*
        if (isGrounded)
        {
            isGrounded = false;
            Jump();
        }
        */

        if(movementInput.x != 0f)
        {
            if(movementInput.x > 0f)
            {
                sr.flipX = false;
            }
            else
            {
                sr.flipX = true;
            }
           
        }



    }

    public void Jump(InputAction.CallbackContext context)
    {
        //started


        //Performed
        if (context.performed && isGrounded)
        {
            Debug.Log("Jump");
            isGrounded = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }


        //Canceled
      
    }

    private void FixedUpdate()
    {
        rb.AddForce(Vector2.right * movementInput.x * movementForce);

        //isGrounded con Raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);


    }
}
