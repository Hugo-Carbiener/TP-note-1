using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Vector3 pos = new Vector3(-8, 1, 0);
    private Vector3 lastPutPosition;


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != "Player") return;
        if (collision.gameObject.tag == "Player")
        {
            respawn(collision.gameObject);
        }
    }


    private void FixedUpdate()
    {
        GameObject[] resp;
        if (Input.GetKeyDown("r"))
        {
            resp =  GameObject.FindGameObjectsWithTag("Player");
            if (resp != null)
            {
                respawn(resp[0]);
            }
        }
    }

    public void respawn(GameObject go)
    {
        lastPutPosition = go.GetComponent<Putting>().getLastPutPosition();
        go.transform.position = lastPutPosition;
        go.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}