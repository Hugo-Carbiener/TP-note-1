using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Putting : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private Vector3 force = new Vector3(1,0,0);
    [SerializeField]
    private float intensityBuildUp = 0.5f;
    private float intensity = 0;
    [SerializeField]
    private Text intensityContainer;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            intensity += intensityBuildUp;
            intensityContainer.text = "intensity : " + intensity;
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
