using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Vector3 pos = new Vector3(-8, 1, 0);

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag != "Player") return;
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.transform.position = pos;
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
                resp[0].transform.position = pos;
            }
        }
    }

}