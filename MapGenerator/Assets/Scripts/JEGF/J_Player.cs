using UnityEngine;

public class J_Player : Mover
{
    private void FixedUpdated()
    {
        float x=Input.GetAxisRaw("Horizontal");
        float y=Input.GetAxisRaw("Vertical");

    UpdateMotor(new Vector3(x,y,0));
    }
    
 
    
}
