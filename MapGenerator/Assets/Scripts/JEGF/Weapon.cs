using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Collidable
{
   public int damagePoint=1;
   public float pushForce=2f;
    public bool isSwinging;

   //Swing
private Animator anim;
   private float coolDown=0.3f;
   private float lastSwing;
    private Transform _tf;

protected override void Start()
{
    base.Start();
    _tf = GetComponentInParent<Transform>();
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        Enemy enemy;
        float direction = _tf.lossyScale.x / Mathf.Abs(_tf.lossyScale.x);
        if (collision.gameObject.TryGetComponent<Enemy>(out enemy))
        {
            if (isSwinging == true)
                enemy.TakeDamage(damagePoint, new Vector3(pushForce * direction, pushForce));
        }
    }


    private void Swing()
   {
       anim.SetTrigger("Swing");
        isSwinging =true;
        StartCoroutine(cancelSwing());
   }

    private IEnumerator cancelSwing()
    {
        yield return new WaitForSeconds(0.1f);
        isSwinging = false;
    }
}
