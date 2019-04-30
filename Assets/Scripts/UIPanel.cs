using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanel : MonoBehaviour
{

    public Text velocityText;
    public Image MainEnginesLight;
    public Image ControlEnginesLight;
    public Image LaserLight;

    public Text scoreText;

    public GameObject ship;
   
    private void Start()
    {
        Asteroid.OnDestroy += OnAsteroidDestroy;
    }

    void Update()
    {
        Rigidbody2D shipRB = ship.GetComponent<Rigidbody2D>();
        float velocity = (int)(shipRB.velocity.magnitude * 100.0f);
        velocityText.text = ""+velocity;

        ShipControll shipControll = ship.GetComponent<ShipControll>();
        LaserGun laserGun = ship.GetComponent<LaserGun>();

        setLight(MainEnginesLight, shipControll.engineOn);
        setLight(ControlEnginesLight, shipControll.controlEnginesOn);
        setLight(LaserLight, laserGun.isShoting);
    }

    void setLight(Image img, bool value)
    {
        Light light = img.GetComponent<Light>();
        light.turn(value);
    }

    public void OnAsteroidDestroy()
    {
        scoreText.text = ""+(++GameHandler.score);
    }

}
