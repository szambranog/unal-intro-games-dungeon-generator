using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePJ : MonoBehaviour
{
    private float xSpeed=4f;
    private float JumpForce=15f;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rigidBody;
    private Vector3 moveDelta;
    private float x;
    private float y;
    private bool Grounded;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        
        moveDelta=new Vector3(x,y,0);
        if (moveDelta.x>0){
            transform.localScale=new Vector3(5,4,1);
        }else if(moveDelta.x<0){
            transform.localScale=new Vector3(-5,4,0);
        }


        if (Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f,Vector2.down,0.1f))
        {
            Grounded = true;
        }
        else Grounded = false;

        if (Input.GetKeyDown(KeyCode.Space)&& Grounded)
        {
            Jump();
        }
       
    }

    private void FixedUpdate()
    {
        transform.Translate(moveDelta*Time.deltaTime*xSpeed);
    }
    private void Jump()
    {
        rigidBody.velocity=Vector2.up*JumpForce;
    }
}
