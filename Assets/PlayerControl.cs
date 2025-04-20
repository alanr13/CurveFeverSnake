using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerControl : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float rotationSpeed = 200f;
    public List<GameObject> bodyParts = new List<GameObject>();

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
        
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.linearVelocity = bodyParts[0].transform.right * movementSpeed;
        if (Input.GetAxis("Horizontal") != 0)
        {
            bodyParts[0].transform.Rotate(new Vector3(0, 0, -rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal")));
        }

        if (bodyParts.Count > 1)
        {
            for (int i = 1; i < bodyParts.Count; i++)
            {
                NewMonoBehaviourScript newMonoBehaviourScript = bodyParts[0].GetComponent<NewMonoBehaviourScript>();
                bodyParts[i].transform.rotation = newMonoBehaviourScript.markers[0].rotation;
            }
        }
    }
}
