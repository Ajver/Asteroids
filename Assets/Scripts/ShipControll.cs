using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class ShipControll : MonoBehaviour
{

    public delegate void GameOverAction();
    public static event GameOverAction OnGameOver;

    public float acceleration;
    public float rotateAcceleration;
    public float damping;
    public float rotateDamping;

    public bool engineOn = false;
    public bool controlEnginesOn = false;

    public ParticleSystem engineParticles;
    public ParticleSystem LeftRCSParticles;
    public ParticleSystem RightRCSParticles;

    public SpriteRenderer sprite;

    public ParticleSystem destroyParticles;
    public ParticleSystem burnParticles;

    private bool isAlive = false;

    private Rigidbody2D rigidbody;

    private void Start()
    {
        isAlive = true;
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        if (!isAlive)
            return;

        processMoving();
        processRotating();
    }

    void processMoving()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Vector2 accVector = transform.up * acceleration * Time.deltaTime;
            rigidbody.velocity += accVector;

            if(rigidbody.velocity.sqrMagnitude > 100)
                rigidbody.velocity *= 0.95f;

            engineParticles.Emit(1);
            engineOn = true;
        }
        else
        {
            Vector2 dampingVel = rigidbody.velocity * damping * Time.deltaTime;
            rigidbody.velocity -= dampingVel;
            engineOn = false;
        }
    }

    void processRotating()
    {
        float rotateDir = Input.GetAxisRaw("Horizontal");
        if (controlEnginesOn = (rotateDir != 0.0f))
        {
            int emit = (int)(120.0f * Time.deltaTime);

            if(rotateDir > 0)
                LeftRCSParticles.Emit(emit);
            else
                RightRCSParticles.Emit(emit);

            rigidbody.angularVelocity -= rotateDir * rotateAcceleration * Time.deltaTime; 
        }
        else
        {
            int emit = (int)(300.0f * Time.deltaTime);
            float margin = 2.0f;

            if (rigidbody.angularVelocity > margin)
                LeftRCSParticles.Emit(emit);
            else if(rigidbody.angularVelocity < -margin)
                RightRCSParticles.Emit(emit);

            float dampingVel = rigidbody.angularVelocity * rotateDamping * Time.deltaTime;
            rigidbody.angularVelocity -= dampingVel;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Asteroid")
        {
            gameOver();
        }
    }

    void gameOver()
    {
        isAlive = false;

        destroyParticles.Emit(100);
        burnParticles.Emit(50);

        OnGameOver();

        sprite.enabled = false;
        this.enabled = false;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        Destroy(this.gameObject, 0.3f);
    }

}
