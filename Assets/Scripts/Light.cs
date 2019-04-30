using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Light : MonoBehaviour
{

    public Image lightSprite;
    bool isOn = false;

    private void Start()
    {
        lightSprite.enabled = false;
    }

    public void turn(bool value)
    {
        if (isOn == value)
            return;

        isOn = value;
        lightSprite.enabled = value;
    }

    public void turnOn()
    {
        turn(true);
    }

    public void turnOf()
    { 
        turn(false);
    }

}
