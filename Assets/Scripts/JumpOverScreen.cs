using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpOverScreen : MonoBehaviour
{
    void Update()
    {
        jumpOverScreen();
    }

    void jumpOverScreen()
    {
        float halfScreenWidth = MainClass.mapWidthUnits * 0.5f;
        float halfScreenHeight = MainClass.mapHeightUnits * 0.5f;

        Vector3 newPosition = transform.position;

        if (transform.position.x > halfScreenWidth)
            newPosition.x = -halfScreenWidth;
        else if (transform.position.x < -halfScreenWidth)
            newPosition.x = halfScreenWidth;

        if (transform.position.y > halfScreenHeight)
            newPosition.y = -halfScreenHeight;
        else if (transform.position.y < -halfScreenHeight)
            newPosition.y = halfScreenHeight;

        transform.position = newPosition;
    }
}
