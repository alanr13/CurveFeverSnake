using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 200f;
    public Transform head;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        float speedX = Input.GetAxisRaw("Horizontal");
        float speedY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(speedX, speedY).normalized;

        // Obracaj w prawo podczas trzymania D
        if (Input.GetKey(KeyCode.D))
        {
            head.Rotate(Vector3.forward * -rotationSpeed); // obrót w prawo (wokó³ Z)
        }
        if (Input.GetKey(KeyCode.A))
        {
            head.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime); // obrót w lewo
        }
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
        animator.SetTrigger("Move");
    }
}
