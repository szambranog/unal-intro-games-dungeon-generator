using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePJ : MonoBehaviour
{
    public float Speed;
    public float JumpForce;

    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private bool Grounded;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Physics2D.Raycast(transform.position, Vector3.down, 0.5f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.W)&& Grounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(Horizontal*Speed, Rigidbody2D.velocity.y);
    }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up*JumpForce);
    }
}
