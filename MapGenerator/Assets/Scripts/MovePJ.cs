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
    private Spawnpj spawn;
    public GameObject[] puntos;
    private Vector3 place;
    private Vector3 vacio=new Vector3(0,0,0);
    private Vector3 point;
    private float x;
    private float y;
    private bool Grounded;
    private bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        puntos = GameObject.FindGameObjectsWithTag("Spawnpj");
        foreach (GameObject spawnpj in puntos)
        {
            spawn=spawnpj.GetComponent<Spawnpj>();
            place = spawn.spawnpj();
            if (place != vacio)
            {
                point = place;
                Debug.Log(point);
            }
        }
        transform.position = point;
        boxCollider = GetComponent<BoxCollider2D>();
        rigidBody=GetComponent<Rigidbody2D>();
        GameEvent.OnPlayerDies += OnPlayerDies;
        GameEvent.OnPlayerRespawn += OnPlayerRespawn;
    }
    
    private void OnPlayerDies()
    {
        canMove = false;
    }

    private void OnPlayerRespawn()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
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
