using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;

    public Transform cameraPosition1;
    public Transform cameraPosition2;
    public Transform cameraPosition3;
    public Transform cameraPosition4;

    // Update is called once per frame
    void Update()
    {
        // Determine the camera postion based on the player's
        if (player.position.x > 0)
        {
            if (player.position.z > 0)
            {
                transform.position = cameraPosition1.position;
            }
            else
            {
                transform.position = cameraPosition4.position;
            }
        }
        else
        {
            if (player.position.z > 0)
            {
                transform.position = cameraPosition2.position;
            }
            else
            {
                transform.position = cameraPosition3.position;
            }
        }
    }
}
