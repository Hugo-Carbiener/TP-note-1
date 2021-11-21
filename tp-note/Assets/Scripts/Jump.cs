using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 up = new Vector3(0, 1, 0);
    [SerializeField] [Range(1,20)] private float verticalSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("p"))
        {
            if (rb.velocity != null)
            {
                // Reset vertical velocity to make jump amplitude 
                // independent of current vertical speed.
                //rb.velocity = new Vector2(rb.velocity.x, 0f);

                // Apply jump force to the rigidbody
                rb.AddForce(up * verticalSpeed, ForceMode.Impulse);
            }
        }
    }
}
