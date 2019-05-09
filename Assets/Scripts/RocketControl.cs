using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControl : MonoBehaviour
{

    public float waitTime = 1.5f;

    public Animator animator;
    
    void Update()
    {
        waitTime -= Time.deltaTime;
        
        if(waitTime <= 0.0f)
            Boom();
    }
     
    public void Boom()
    {
        animator.SetTrigger("BOOM");
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Destroy(gameObject, 1.0f);
    }
    
}
