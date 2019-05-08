using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserGun : MonoBehaviour
{

    public Transform firePoint;
    public GameObject laserPrefab;
    public float laserSpeed = 1.0f;
    public float fireRate = 0.5f;
    
    public bool isShoting = false;
    
    private float nextFireTimer;

    private bool isShipAlive = true;

    private void Start()
    {
        ShipControll.OnGameOver += OnGameOver;
    }

    void resetFireTimer()
    {
        nextFireTimer = fireRate;
    }
    
    void Update()
    {
        if (!isShipAlive)
            return;

        if (Input.GetKeyDown(KeyCode.Space))
            startShoting();
        else if (Input.GetKeyUp(KeyCode.Space))
            stopShoting();

        processShoting();
    }

    void processShoting()
    {   
        nextFireTimer -= Time.deltaTime;

        if (!isShoting)
            return;

        if (nextFireTimer <= 0.0f)
        {
            resetFireTimer();
            shot();    
        }    
    }

    void shot()
    {
        Vector2 laserVelocity = transform.up * laserSpeed;
        GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        laser.GetComponent<Rigidbody2D>().velocity = laserVelocity;
        SoundManager.playSound(SoundManager.Sound.LASER_GUN);
    }

    void startShoting()
    {
        isShoting = true;
    }

    void stopShoting()
    {
        isShoting = false;
    }

    void OnGameOver()
    {
        isShipAlive = false;
    }
}
