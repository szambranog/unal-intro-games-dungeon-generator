using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    public int hitpoint=10;
    public int maxHitpoint=10;
    public float pushRecoverySpeed=0.2f;


    protected float inmuneTime=0.5f;
    protected float lastInmune;

    protected Vector3 pushDirection;

    protected virtual void RecieveDamage(Damage dmg)
    {
        if(Time.time-lastInmune>inmuneTime){
            lastInmune=Time.time;
            hitpoint-=dmg.damageAmount;
            pushDirection=(transform.position-dmg.origin).normalized*dmg.pushForce;

            

            if(hitpoint<=0){
                hitpoint=0;
                Death();
            }
        }
    }
    protected virtual void Death()
    {

    }
}
