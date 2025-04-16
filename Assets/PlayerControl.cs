using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerControl : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 200f;
    public List<Transform> bodyParts;

    private Rigidbody2D rb;
    private Vector2 moveDirection;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        gameObject.GetComponent<NewMonoBehaviourScript>().AddToMarkersList(bodyParts);
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
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
        if (Input.GetAxis("Horizontal") != 0)
        {
            bodyParts[0].transform.Rotate(new Vector3(0, 0, -rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal")));
            for (int i = 1; i < bodyParts.Count; i++)
            {
                NewMonoBehaviourScript marker = bodyParts[i - 1].GetComponent<NewMonoBehaviourScript>();
                bodyParts[i].transform.position = marker.markers[i-1].position;
                bodyParts[i].transform.rotation = marker.markers[i-1].rotation;
            }
        }
    }
}
