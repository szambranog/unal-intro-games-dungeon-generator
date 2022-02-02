using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
   public int damagePoint=1;
   public float pushForce=2f;

   //Swing
private Animator anim;
   private float coolDown=0.5f;
   private float lastSwing;

protected override void Start()
{
    base.Start();
    anim=GetComponent<Animator>();
}
   protected override void Update()
   {
       base.Update();

       if (Input.GetMouseButtonDown(0))
       {
           if (Time.time-lastSwing>coolDown)
           {
               lastSwing=Time.time;
               Swing();
           }
       }
   }
   protected override void OnCollide(Collider2D coll)
   {
       if ( coll.name=="Player_0"){
           return;
       }else {
           if (coll.tag=="Fighter"){
             Damage dmg=new Damage
            {
                damageAmount=damagePoint,
                origin=transform.position,
                pushForce=pushForce
            };
           coll.SendMessage("RecieveDamage", dmg);
           Debug.Log(coll.name);
       }}
              
   }
   private void Swing()
   {
       anim.SetTrigger("Swing");

   }
}
