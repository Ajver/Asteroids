using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeScaleControl : MonoBehaviour
{

    public float timeScale = 1.0f;

    void Update()
    {
        if(timeScale != Time.timeScale && timeScale > 0.0f)
        {
            Time.timeScale = timeScale;
        }
        //
    }
    
}
