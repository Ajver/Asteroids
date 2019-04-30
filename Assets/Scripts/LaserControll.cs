using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControll : MonoBehaviour
{

    public float liveTime = 1.0f;

    void Start()
    {
        Destroy(this.gameObject, liveTime);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "Asteroid")
        {
            Rigidbody2D thisRigidbody = GetComponent<Rigidbody2D>();
            collider.GetComponent<Rigidbody2D>().AddForce(thisRigidbody.velocity);
            Destroy(this.gameObject);
        }
    }
}
