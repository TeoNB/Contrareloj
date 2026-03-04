using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
	// Referencias a componentes
	private PlayerInput playerInput;
    private Rigidbody2D rb;

	// Variables de movimiento
	float moveSpeed;
    float jumpForce;
    float horizontalMove;

	// Variables de estado
	Vector2 moveInput;
    bool isGrounded;

	
    
	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        moveSpeed = 2f;
        jumpForce = 5f;

	}

    // Update is called once per frame
    void Update()
    {
        moveInput = playerInput.actions["Move"].ReadValue<Vector2>();
        horizontalMove = moveSpeed * moveInput.x;
	}
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalMove, rb.linearVelocity.y);
    }

	// realizar salto usando el sistema de input de Unity, se llama desde el InputAction del PlayerInput usando el evento "performed" y callback "Jump"
	public void Jump(InputAction.CallbackContext callbackcontext)
    {
        if (callbackcontext.performed && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false; 
            Debug.Log("Jump");       
        }
        
	}

	void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = true;
            Debug.Log("He chocado con el suelo");
        }
	}

	void OnCollisionStay2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Suelo"))
        {
            Debug.Log("Estoy tocando el suelo");
		}
	}

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            isGrounded = false;
			Debug.Log("He dejado de tocar el suelo");
        }
	}
}
