using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Putting : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private Vector3 force = new Vector3(1,0,0);
    [SerializeField]
    private float intensityBuildUp = 0.5f;
    [Range(0, 100)]
    private float intensity = 0;
    [SerializeField]
    private Slider intensityBar;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
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
            if(rb.velocity == Vector3.zero)
            {
                force = transform.position - Camera.main.transform.position;
                rb.AddForce(force * intensity);
            }
            intensity = 0;
        }
    }
}
