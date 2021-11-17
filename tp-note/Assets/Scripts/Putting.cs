using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Putting : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private Vector3 force = new Vector3(1,0,0);
    [SerializeField]
    private float intensity = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            rb.AddForce(force * intensity);
        }
    }
}
