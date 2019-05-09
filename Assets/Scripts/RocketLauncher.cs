using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{

    public Transform firePoint;

    public GameObject rocketPrefab;
    public float rocketSpeed = 2.0f;
    public float nextRocketWaitTime;

    private float nextRocketTimer;

    private bool isShipAlive = true;

    void Start()
    {
        ShipControll.OnGameOver += OnGameOver;
        RestartNextRocketTimer();
    }

    void Update()
    {
        if (!isShipAlive)
            return;

        nextRocketTimer -= Time.deltaTime;

        if(nextRocketTimer <= 0.0f)
        {
            if(GetRocketShotButtonDown())
            {
                LaunchRocket();
                RestartNextRocketTimer();
            }
        }

    }

    private bool GetRocketShotButtonDown()
    {
        return Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift);
    }

    void LaunchRocket()
    {
        RestartNextRocketTimer();
        GameObject rocket = Instantiate(rocketPrefab, firePoint.position, firePoint.rotation);
        rocket.GetComponent<Rigidbody2D>().velocity = firePoint.up * rocketSpeed;
    }

    private void RestartNextRocketTimer()
    {
        nextRocketTimer = nextRocketWaitTime;
    }

    public void OnGameOver()
    {
        isShipAlive = false;
    }

}
