using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    private Putting putting;
    private LineRenderer line;
    private Vector3 endPos;
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
        putting = this.GetComponent<Putting>();
        line = gameObject.AddComponent<LineRenderer>();
        line.startColor = Color.black;
        line.endColor = Color.black;
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;
        Material whiteDiffuseMat = new Material(Shader.Find("Unlit/Texture"));
        line.material = whiteDiffuseMat;
    }

    private void FixedUpdate()
    {
        line.SetPosition(0, transform.position);
        endPos = new Vector3(transform.position.x - cam.transform.position.x, 0, transform.position.z - cam.transform.position.z);
        line.SetPosition(1, endPos*10);
    }
}
