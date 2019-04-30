using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadarCameraFollow : MonoBehaviour
{

    public GameObject ship;

    private void LateUpdate()
    {
        Vector3 newPosition = ship.transform.position;
        newPosition.z = transform.position.z;
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, ship.transform.rotation.eulerAngles.z);
    }
}
