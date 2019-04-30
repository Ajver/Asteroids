using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ShipControll : MonoBehaviour
{

    public float acceleration;
    public float rotateAcceleration;
    public float damping;
    public float rotateDamping;

    public bool engineOn = false;
    public bool controlEnginesOn = false;

    public ParticleSystem engineParticles;
    public ParticleSystem LeftRCSParticles;
    public ParticleSystem RightRCSParticles;

    private Rigidbody2D rigidbody;
    private EmissionModule emission;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        emission = engineParticles.emission;
    }
    
    void Update()
    {
        processMoving();
        processRotating();
    }

    void processMoving()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Vector2 accVector = transform.up * acceleration * Time.deltaTime;
            rigidbody.velocity += accVector;
            engineParticles.Emit(1);
            engineOn = true;
        }
        else
        {
            rigidbody.velocity *= damping;
            engineOn = false;
        }
    }

    void processRotating()
    {
        float rotateDir = Input.GetAxisRaw("Horizontal");
        if (controlEnginesOn = (rotateDir != 0.0f))
        {
            int emit = 2;
            if(rotateDir > 0)
            {
                LeftRCSParticles.Emit(emit);
            }
            else
            {
                RightRCSParticles.Emit(emit);
            }

            rigidbody.angularVelocity -= rotateDir * rotateAcceleration * Time.deltaTime; 
        }
        else
        {
            int emit = 5;
            float margin = 2.0f;
            if (rigidbody.angularVelocity > margin)
            {
                LeftRCSParticles.Emit(emit);
            }
            else if(rigidbody.angularVelocity < -margin)
            {
                RightRCSParticles.Emit(emit);
            }

            rigidbody.angularVelocity *= rotateDamping;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Asteroid")
        {
            // Game Over
            SoundManager.playSound(SoundManager.Sound.DESTROY);
            Debug.Log("GameOver");
        }
    }
}
