using UnityEngine;
using UnityEngine.Animations;

public class PlayerControl : MonoBehaviour
{
    public float movementSpeed;
    Rigidbody2D rb;
    private Vector2 moveDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
    }

    void Move()
    {
        rb.linearVelocity = new Vector2 (moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
    }
}
