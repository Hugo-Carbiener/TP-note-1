using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballIndicator : MonoBehaviour
{
    [SerializeField]
    private GameObject golfball;
    

    // Update is called once per frame
    void Update()
    {
        transform.position = golfball.transform.position;
    }
}
