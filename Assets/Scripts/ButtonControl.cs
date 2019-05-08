using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonControl : MonoBehaviour
{

    public Image lightImg;
    
    public void EnableLight()
    {
        setLight(lightImg, true);
    }

    public void DisableLight()
    {
        setLight(lightImg, false);
    }

    void setLight(Image img, bool value)
    {
        Light light = img.GetComponent<Light>();
        light.turn(value);
    }

}
