using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketControl : MonoBehaviour
{

    public float waitTime = 1.5f;

    public GameObject sprite;

    private bool isAlive = true;
    
    void Update()
    {
        if (!isAlive)
            return;

        waitTime -= Time.deltaTime;
        
        if(waitTime <= 0.0f)
        {
            Boom();
        }
    }

    void Boom()
    {
        isAlive = false;
        sprite.SetActive(false);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        Destroy(gameObject, 0.5f);
        Debug.Log("BOOM!");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Asteroid")
        {
            Boom();
        }
    }

}
