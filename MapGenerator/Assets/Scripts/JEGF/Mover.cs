using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mover : Fighter
{
    protected BoxCollider2D boxCollider;
    protected Vector3 moveDelta;
    protected float ySpeed=0.75f;
    protected float xSpeed=1f;


    protected virtual void Start()
    {
        boxCollider=GetComponent<BoxCollider2D>();
    }
    
 
    protected virtual void UpdateMotor(Vector3 input)
    {
               //Resetear vector moveDelta
        moveDelta=input;

        //Cambiar la idreccion del sprite si va hacia un lado o hacia el otro
        if (moveDelta.x>0){
            transform.localScale=Vector3.one;
        }else if(moveDelta.x<0){
            transform.localScale=new Vector3(-1,1,0);
        }
        //movimiento del personaje
        transform.Translate(moveDelta*Time.deltaTime);
    }
}
