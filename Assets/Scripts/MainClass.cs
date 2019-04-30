using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainClass : MonoBehaviour
{
    public static float screenHeightUnits;
    public static float screenWidthUnits;

    public static float mapWidthUnits;
    public static float mapHeightUnits;

    void Update()
    {
        screenHeightUnits = 2.0f * Camera.main.orthographicSize;
        screenWidthUnits = (Screen.width * screenHeightUnits) / Screen.height;

        mapWidthUnits = screenWidthUnits;
        mapHeightUnits = screenHeightUnits;
    }
    
}
