using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player") return;
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("F�licitations ! Vous gagnez la partie.");
        }
    }
}
