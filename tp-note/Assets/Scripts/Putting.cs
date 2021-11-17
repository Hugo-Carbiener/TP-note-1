using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Putting : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 force;
    [SerializeField]
    private float velocityMultiplier = 1f;
    [SerializeField]
    private float intensityBuildUp = 0.1f;
    [Range(0, 100)]
    private float intensity = 0;
    [SerializeField]
    private Slider intensityBar;
    private GameObject shootIndicator;
    private GameObject ShootIndicator;
    private Vector3 velocity;
    [SerializeField]
    private float minVelocity = 2f;

    // for the shot indicator
    private Color indicatorColor;
    private Color newColor;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        shootIndicator = GameObject.Find("ShootIndicator");
        indicatorColor = GameObject.Find("ShootIndicator").GetComponent<Image>().color;
        newColor = indicatorColor;
        newColor.r += 20;
    }

    private void Update()
    {
        // stop the ball if it is too slow
        if (GetVectorNorm(rb.velocity) <= minVelocity && rb.velocity != Vector3.zero)
        {
            rb.velocity = Vector3.zero;
            shootIndicator.SetActive(true);
            shootIndicator.GetComponent<Image>().color = indicatorColor;
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
                shootIndicator.GetComponent<Image>().color = newColor;
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
                rb.AddForce(force * intensity * velocityMultiplier);
                shootIndicator.SetActive(false);
            }
            intensity = 0;
        }
    }

    private float GetVectorNorm(Vector3 vect)
    {
        return Mathf.Abs(vect.x) + Mathf.Abs(vect.y) + Mathf.Abs(vect.z);
    }
}
