using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{

    public delegate void DestroyAction();
    public static event DestroyAction OnDestroy;

    public ParticleSystem destroyParticles;
    public ParticleSystem boomParticles;

    public static int asteroidsCount;

    private Animator animator;
    private bool isAlive = true;
    private AsteroidType type;

    enum AsteroidType
    {
        BIG = 3,
        MEDIUM = 2,
        SMALL = 1,
        DESTROYED = 0,
    }

    public void Start()
    {
        type = (AsteroidType)Mathf.Floor(Random.value * 3 + 1);

        animator = GetComponent<Animator>();

        setupByType();

        Rigidbody2D rigidbody = GetComponent<Rigidbody2D>();
        float randomAngularVelocity = 15.0f + Random.value * 15.0f;
        randomAngularVelocity *= Random.value > 0.5f ? 1.0f : -1.0f;
        rigidbody.angularVelocity = randomAngularVelocity;

        Vector3 randomVelocity = new Vector3(0.0f, Random.value, 0.0f);
        randomVelocity.x = Mathf.Sqrt(1.0f - randomVelocity.y * randomVelocity.y);
        randomVelocity.x *= Random.value > 0.5f ? 1.0f : -1.0f;
        randomVelocity.y *= Random.value > 0.5f ? 1.0f : -1.0f;
        randomVelocity *= 0.2f + Random.value * 0.5f;
        rigidbody.velocity = randomVelocity;
    }

    void setupByType()
    {
        CircleCollider2D collider = GetComponent<CircleCollider2D>();

        switch (type)
        {
            case AsteroidType.BIG:
                animator.SetTrigger("isBig");
                collider.radius = 0.11f;
                break;
            case AsteroidType.MEDIUM:
                animator.SetTrigger("isMedium");
                collider.radius = 0.08f;
                break;
            case AsteroidType.SMALL:
                animator.SetTrigger("isSmall");
                collider.radius = 0.06f;
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!isAlive)
            return;

        if (collider.tag == "Laser")
        {
            if (--type == AsteroidType.DESTROYED)
            {
                asteroidsCount--;
                destroyParticles.Emit(30);
                boomParticles.Emit(10);
                Destroy(this.gameObject, 0.375f);
                isAlive = false;
                SoundManager.playSound(SoundManager.Sound.ASTEROID_DESTROY);
                OnDestroy();
            }
            else
            {
                boomParticles.Emit(30);
                SoundManager.playSound(SoundManager.Sound.ASTEROID_HIT);
            }

            animator.SetTrigger("boom");
        }

        setupByType();
    }

}
