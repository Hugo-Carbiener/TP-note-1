using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Putting : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 force;
    [SerializeField]
    private float intensityBuildUp = 0.5f;
    [Range(0, 100)]
    private float intensity = 0;
    [SerializeField]
    private Slider intensityBar;
    [SerializeField]
    private Vector3 velocity;
    [SerializeField]
    private float minVelocity = 2f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // stop the ball if it is too slow
        if (GetVectorNorm(rb.velocity) <= minVelocity)
        {
            rb.velocity = Vector3.zero;
        }

        velocity = rb.velocity;
        if (Input.GetKey(KeyCode.Space))
        {
            // while intensity < 100 and space is pressed, build up intensity
            if(intensity < 100)
            {
                intensity += intensityBuildUp;
                intensityBar.value = intensity;
                intensityBar.GetComponentInChildren<Text>().text = "Intensity = " + intensity;
            } 
            else
            {
                intensity = 100;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // release ball
            if(rb.velocity == Vector3.zero)
            {
                force = transform.position - Camera.main.transform.position;
                force.y = 0;
                rb.AddForce(force * intensity);
            }
            intensity = 0;
        }
    }

    private float GetVectorNorm(Vector3 vect)
    {
        return Mathf.Abs(vect.x) + Mathf.Abs(vect.y) + Mathf.Abs(vect.z);
    }
}
