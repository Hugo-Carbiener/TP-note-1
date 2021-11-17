using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField]
    private GameObject golfball;
    [SerializeField]
    private float rotationSpeed = 1;
    private Vector3 offset;

    void Update()
    {

        transform.LookAt(golfball.transform);
        if(Input.GetKey(KeyCode.Q) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(golfball.transform.position, Vector3.up, rotationSpeed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(golfball.transform.position, Vector3.up, -rotationSpeed);
        }
    }
}
