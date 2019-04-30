using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioClip laserGun;
    public AudioClip destroy;
    public AudioClip asteroidHit;
    public AudioClip asteroidDestroy;

    private static AudioClip laserGunSound;
    private static AudioClip destroySound;
    private static AudioClip asteroidHitSound;
    private static AudioClip asteroidDestroySound;

    private static AudioSource audioSource;

    public enum Sound
    {
        LASER_GUN,
        DESTROY,
        ASTEROID_HIT,
        ASTEROID_DESTROY,
    }

    void Start()
    {
        laserGunSound = laserGun;
        destroySound = destroy;
        asteroidHitSound = asteroidHit;
        asteroidDestroySound = asteroidDestroy;

        audioSource = GetComponent<AudioSource>();
    }

    public static void playSound(Sound soundName)
    {
        switch(soundName)
        {
            case Sound.LASER_GUN:
                audioSource.PlayOneShot(laserGunSound);
                break;
            case Sound.DESTROY:
                audioSource.PlayOneShot(destroySound);
                break;
            case Sound.ASTEROID_DESTROY:
                audioSource.PlayOneShot(asteroidDestroySound);
                break;
            case Sound.ASTEROID_HIT:
                audioSource.PlayOneShot(asteroidHitSound);
                break;
            default:
                Debug.LogError("Error: No sound found: " + soundName);
                break;
        }
    }
}
